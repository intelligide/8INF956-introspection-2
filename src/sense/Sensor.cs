using System;

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

    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class SensorAttribute : Attribute
    {
        EDataType Type;

        EUnit Unit;

        public SensorAttribute(EDataType type, EUnit unit)
        {
            this.Type = type;
            this.Unit = unit;
        }
    }


    public interface Sensor
    {
        float Sense();
    }
}
