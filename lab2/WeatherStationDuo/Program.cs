namespace WeatherStationDuo
{
    internal static class Program
    {
        private static void Main()
        {
            var wdIn = new WeatherData();
            var wdOut = new WeatherData();

            var display = new Display(wdIn, wdOut);
            wdIn.RegisterObserver(display, 2);
            wdOut.RegisterObserver(display, 2);

            var statsDisplay = new StatsDisplay(wdIn, wdOut);
            wdIn.RegisterObserver(statsDisplay, 0);
            wdOut.RegisterObserver(statsDisplay, 1);

            wdIn.SetMeasurements(3, 0.7, 760);
            wdOut.SetMeasurements(4, 0.8, 761);

            wdOut.RemoveObserver(statsDisplay);

            wdIn.SetMeasurements(10, 0.8, 761);
            wdOut.SetMeasurements(-10, 0.8, 761);
        }
    }
}