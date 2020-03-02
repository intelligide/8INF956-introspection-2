using System;
using sense;

[Sensor(EDataType.Temp, EUnit.Celsius)]
public class CelsiusTempSensor: Sensor
{
    public EDataType DataType { get; set; }
    public EUnit Unit { get; set; }

    public float Sense()
    {
        var rand = new Random();
        return rand.Next(17, 23);
    }
}

[Sensor(EDataType.Temp, EUnit.Kelvin)]
public class KelvinTempSensor: Sensor
{
    public EDataType DataType { get; set; }
    public EUnit Unit { get; set; }

    public float Sense()
    {
        var rand = new Random();
        return rand.Next(290, 296);
    }
}
