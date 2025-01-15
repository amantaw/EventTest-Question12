using static EventTest.TemperatureChangedEventArgs;

public class Program
{
    public static void Main()
    {
        // Create instances of the classes
        TemperatureSensor sensor = new TemperatureSensor();
        TemperatureDisplay display = new TemperatureDisplay();

        // Subscribe to the event
        sensor.TemperatureChanged += display.OnTemperatureChanged;

        // Change the temperature, triggering the event
        sensor.CurrentTemperature = 25; // Event triggered here
        sensor.CurrentTemperature = 30; // Event triggered here
    }
}

