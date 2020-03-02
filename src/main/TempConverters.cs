using System;
using sense;

[Converter(EUnit.Kelvin, EUnit.Celsius)]
public class KelvinToCelsiusConverter: Converter
{
    public KelvinToCelsiusConverter(Sensor sensor) : base(sensor)
    {
    }

    protected override float Convert(float value)
    {
        return value - 273f;
    }
}
