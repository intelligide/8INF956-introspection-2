using System;
using System.Threading;
using sense;

namespace main
{
    class Program
    {
        static void Main(string[] args)
        {
            SensorManager sensorManager = new SensorManager();
            sensorManager.AddSensor(SensorFactory.CreateSensor(EDataType.Temp, EUnit.Kelvin));

            while(true)
            {
                sensorManager.UpdateSensors();
                Thread.Sleep(5000);
            }
        }
    }
}
