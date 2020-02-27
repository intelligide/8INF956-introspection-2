using System;

namespace sense
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ConverterAttribute : Attribute
    {
        EUnit InUnit;

        EUnit OutUnit;

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
