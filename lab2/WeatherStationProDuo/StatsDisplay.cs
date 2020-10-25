using System;

namespace WeatherStationProDuo
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly WeatherDataIn _weatherDataIn;
        private readonly WeatherDataOut _weatherDataOut;
        private readonly WeatherStats _weatherStatisticsIn = new WeatherStats();
        private readonly WeatherStats _weatherStatisticsOut = new WeatherStats();

        public StatsDisplay(WeatherDataIn weatherDataIn, WeatherDataOut weatherDataOut)
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