using System;
using System.Collections.Generic;
using System.Reflection;

namespace sense
{
    public class SensorManager
    {
        private List<Sensor> sensors;

        public SensorManager()
        {
            foreach(Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                foreach(Type type in assembly.GetTypes()) {
                if (type.GetCustomAttributes(typeof(ConverterAttribute), true).Length > 0) {
                    // yield return type;
                }
            }
            }
            
        }

        public void s()
        {
        }

        private void UpdateSensors()
        {
            foreach (var sensor in sensors)
            {
                sensor.Sense();
            }
        }
    }
}
