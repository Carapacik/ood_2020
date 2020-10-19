using System;

namespace WeatherStationDuo
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly WeatherStats _weatherStatisticsIn = new WeatherStats();
        private readonly WeatherStats _weatherStatisticsOut = new WeatherStats();

        private readonly WeatherData _weatherDataIn;
        private readonly WeatherData _weatherDataOut;

        public StatsDisplay(WeatherData weatherDataIn, WeatherData weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(WeatherInfo data, IObservable<WeatherInfo> observable)
        {
            if (_weatherDataIn == observable)
            {
                Console.WriteLine("IN");
                _weatherStatisticsIn.PrintStatistics(data);
            }

            if (_weatherDataOut != observable) return;
            Console.WriteLine("OUT");
            _weatherStatisticsOut.PrintStatistics(data);
        }
    }
}