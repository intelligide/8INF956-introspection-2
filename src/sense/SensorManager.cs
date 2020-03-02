using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace sense
{
    public class SensorManager
    {
        private Dictionary<EUnit, Type> converters = new Dictionary<EUnit, Type>();

        private List<Sensor> sensors = new List<Sensor>();

        private Dictionary<Sensor, Visualizer> visualizers = new Dictionary<Sensor, Visualizer>();

        public SensorManager()
        {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) 
            {
                foreach(Type type in assembly.GetTypes()) 
                {

                    var converterAttrs = type.GetCustomAttributes(typeof(ConverterAttribute), true);

                    if (converterAttrs.Length > 0) 
                    {
                        ConverterAttribute attr  = converterAttrs[0] as ConverterAttribute;
                        converters.Add(attr.InUnit, type);
                    }
                }
            }
        }

        public void AddSensor(Sensor sensor)
        {
            if(converters.ContainsKey(sensor.Unit))
            {
                Converter converter = Activator.CreateInstance(converters[sensor.Unit], sensor) as Converter;

                sensor = converter;
            }

            sensors.Add(sensor);
            visualizers.Add(sensor, new Visualizer(sensor));
        }

        public void RemoveSensor(Sensor sensor)
        {
            sensors.Remove(sensor);
            visualizers.Remove(sensor);
        }

        private Thread UpdateSensorsThread = null;

        public void UpdateSensors()
        {
            if(UpdateSensorsThread == null || !UpdateSensorsThread.IsAlive)
            {
                UpdateSensorsThread = new Thread(UpdateSensorsWorker);
                UpdateSensorsThread.Start();
            }
        }

        private void UpdateSensorsWorker()
        {
            foreach(KeyValuePair<Sensor, Visualizer> entry in visualizers)
            {
                entry.Value.Update();
            }
        }
    }
}
