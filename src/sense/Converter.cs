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

    public class Converter : Sensor
    {
    }
}
