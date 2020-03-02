
using System;

namespace sense
{
    public class Visualizer
    {
        private Sensor sensor;

        public Visualizer(Sensor sensor)
        {
            this.sensor = sensor;
        }

        public void Update()
        {
            Console.WriteLine(sensor.Sense());
        }
    }
}