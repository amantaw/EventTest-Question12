using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventTest
{
    public class TemperatureChangedEventArgs : EventArgs
    {
        public int OldTemperature { get; }
        public int NewTemperature { get; }

        public TemperatureChangedEventArgs(int oldTemperature, int newTemperature)
        {
            OldTemperature = oldTemperature;
            NewTemperature = newTemperature;
        }
        public delegate void TemperatureChangedEventHandler(object sender, TemperatureChangedEventArgs e);

        public class TemperatureSensor
        {
            private int _currentTemperature;

            public event TemperatureChangedEventHandler TemperatureChanged;

            public int CurrentTemperature
            {
                get { return _currentTemperature; }
                set
                {
                    if (_currentTemperature != value)
                    {
                        int oldTemperature = _currentTemperature;
                        _currentTemperature = value;
                        OnTemperatureChanged(oldTemperature, _currentTemperature);
                    }
                }
            }

            protected virtual void OnTemperatureChanged(int oldTemperature, int newTemperature)
            {
                // Check if there are any subscribers and invoke the event
                TemperatureChanged?.Invoke(this, new TemperatureChangedEventArgs(oldTemperature, newTemperature));
            }
        }
        public class TemperatureDisplay
        {
            public void OnTemperatureChanged(object sender, TemperatureChangedEventArgs e)
            {
                Console.WriteLine($"Temperature changed from {e.OldTemperature}°C to {e.NewTemperature}°C.");
            }
        }


    }
}
