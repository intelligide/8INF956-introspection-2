using System;

namespace sense
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public class ConverterAttribute : Attribute
    {
        public EUnit InUnit { get; private set; }

        public EUnit OutUnit { get; private set; }

        public ConverterAttribute(EUnit inUnit, EUnit outUnit)
        {
            this.InUnit = inUnit;
            this.OutUnit = outUnit;
        }
    }

    public abstract class Converter : Sensor
    {
        public Sensor Sensor { get; private set; }
        public EDataType DataType { get; set; }
        public EUnit Unit { get; set; }

        public Converter(Sensor sensor)
        {
            this.Sensor = sensor;
        }

        public float Sense()
        {
            return Convert(this.Sensor.Sense());
        }

        protected abstract float Convert(float value); 
    }
}
