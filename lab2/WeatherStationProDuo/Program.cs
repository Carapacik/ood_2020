namespace WeatherStationProDuo
{
    internal static class Program
    {
        private static void Main()
        {
            var weatherDataIn = new WeatherDataIn();
            var weatherDataOut = new WeatherDataOut();

            var display = new Display(weatherDataIn, weatherDataOut);
            var statsDisplay = new StatsDisplay(weatherDataIn, weatherDataOut);

            weatherDataIn.RegisterObserver(statsDisplay, 2);
            weatherDataOut.RegisterObserver(statsDisplay, 4);
            weatherDataIn.RegisterObserver(display, 2);

            weatherDataIn.SetMeasurements(3, 0.7, 760);
            weatherDataOut.SetMeasurements(4, 0.8, 761, 3, 55);

            weatherDataIn.RemoveObserver(display);

            weatherDataIn.SetMeasurements(10, 0.8, 761);
            weatherDataOut.SetMeasurements(-20, 0.8, 761, 2, 30);
        }
    }
}