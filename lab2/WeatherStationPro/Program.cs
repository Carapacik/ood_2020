namespace WeatherStationPro
{
    internal static class Program
    {
        private static void Main()
        {
            var wd = new WeatherData();

            var display = new Display();
            wd.RegisterObserver(display, 1);

            var statsDisplay = new StatsDisplay();
            wd.RegisterObserver(statsDisplay, 0);

            wd.SetMeasurements(3, 0.7, 760, 4, 60);
            wd.SetMeasurements(4, 0.8, 761, 2, 90);

            wd.RemoveObserver(display);

            wd.SetMeasurements(10, 0.7, 760, 4, 270);
            wd.SetMeasurements(-10, 0.8, 761, 8, 180);
        }
    }
}