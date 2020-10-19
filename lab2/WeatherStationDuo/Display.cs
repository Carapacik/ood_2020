using System;

namespace WeatherStationDuo
{
    public class Display : IObserver<WeatherInfo>
    {
        private readonly WeatherData _weatherDataIn;
        private readonly WeatherData _weatherDataOut;

        public Display(WeatherData weatherDataIn, WeatherData weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(WeatherInfo data, IObservable<WeatherInfo> observable)
        {
            if (_weatherDataIn == observable)
            {
                Console.WriteLine("IN");
            }
            if (_weatherDataOut == observable)
            {
                Console.WriteLine("OUT");
            }
            Console.WriteLine($"Current Temp {data.Temperature}");
            Console.WriteLine($"Current Hum {data.Humidity}");
            Console.WriteLine($"Current Pressure {data.Pressure}");
            Console.WriteLine("----------------");
        }
    }
}