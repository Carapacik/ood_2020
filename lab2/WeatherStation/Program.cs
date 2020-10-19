namespace WeatherStation
{
    internal static class Program
    {
        private static void Main()
        {
            {
                var wd = new WeatherData();

                var display = new Display();
                wd.RegisterObserver(display, 1);

                var statsDisplay = new StatsDisplay();
                wd.RegisterObserver(statsDisplay, 2);

                wd.SetMeasurements(3, 0.7, 760);
                wd.SetMeasurements(4, 0.8, 761);

                wd.RemoveObserver(statsDisplay);

                wd.SetMeasurements(10, 0.8, 761);
                wd.SetMeasurements(-10, 0.8, 761);
            }
        }
    }
}