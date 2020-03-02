using System;
using System.Linq;
using System.Reflection;

namespace sense
{
    public enum EUnit
    {
       Celsius,
       Fahrenheit,
       Kelvin, 
    }

    public enum EDataType
    {
        Temp,
    }

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class SensorAttribute : Attribute
    {
        public EDataType DataType { get; private set; }

        public EUnit Unit { get; private set; }

        public SensorAttribute(EDataType datatype, EUnit unit)
        {
            this.DataType = datatype;
            this.Unit = unit;
        }
    }

    public interface Sensor
    {
        EDataType DataType { get; set; }

        EUnit Unit { get; set; }

        float Sense();
    }

    public static class SensorFactory
    {
        public static Sensor CreateSensor(EDataType datatype, EUnit unit)
        {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) 
            {
                foreach(Type type in assembly.GetTypes()) 
                {
                    var sensorAttrs = type.GetCustomAttributes(typeof(SensorAttribute), true);

                    if (sensorAttrs.Length > 0) 
                    {
                        if(type.GetInterfaces().Any(t => t == typeof(Sensor)))
                        {
                            SensorAttribute attr  = sensorAttrs[0] as SensorAttribute;

                            if(attr.DataType == datatype && attr.Unit == unit)
                            {
                                Sensor sensor = Activator.CreateInstance(type) as Sensor;
                                if(sensor != null)
                                {
                                    sensor.DataType = datatype;
                                    sensor.Unit = unit;
                                }
                                return sensor;
                            }
                        }
                        else
                        {
                            throw new InvalidOperationException(type.Name + " that declares Sensor attribute must implement Sensor interface");
                        }
                    }
                }
            }

            throw new ArgumentException("There is no declared Sensor with data type " + datatype.ToString() + " and unit " + unit.ToString() + ".");
        }
    }
}
