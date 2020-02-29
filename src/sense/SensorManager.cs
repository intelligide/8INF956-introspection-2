using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading;

namespace sense
{
    public class SensorManager
    {
        private Dictionary<EUnit,Converter> converters = new Dictionary<EUnit,Converter>();

        private List<Sensor> sensors = new List<Sensor>();

        public SensorManager()
        {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach(Type type in assembly.GetTypes()) {

                    var converterAttrs = type.GetCustomAttributes(typeof(ConverterAttribute), true);

                    if (converterAttrs.Length > 0) {
                        ConverterAttribute attr  = converterAttrs[0] as ConverterAttribute;
                        Converter converter = Activator.CreateInstance(type) as Converter;
                        if(converter != null) 
                        {
                            converters.Add(attr.InUnit, converter);
                        }
                    }
                }
            }
        }

        public void AddSensor(Sensor sensor)
        {
            sensors.Add(sensor);
        }

        public void RemoveSensor(Sensor sensor)
        {
            sensors.Remove(sensor);
        }

        private Thread UpdateSensorsThread = null;

        public void UpdateSensors()
        {
            if(UpdateSensorsThread == null || !UpdateSensorsThread.IsAlive)
            {
                UpdateSensorsThread = new Thread(UpdateSensorsWorker);
            }
        }

        private void UpdateSensorsWorker()
        {
            foreach (var sensor in sensors)
            {
                sensor.Sense();
            }
        }
    }
}
