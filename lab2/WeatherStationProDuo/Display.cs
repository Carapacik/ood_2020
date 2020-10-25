using System;

namespace WeatherStationProDuo
{
    public class Display : IObserver<WeatherInfo>
    {
        private readonly WeatherDataIn _weatherDataIn;
        private readonly WeatherDataOut _weatherDataOut;

        public Display(WeatherDataIn weatherDataIn, WeatherDataOut weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(WeatherInfo data, IObservable<WeatherInfo> observable)
        {
            if (_weatherDataIn == observable) Console.WriteLine("IN");
            if (_weatherDataOut == observable)
            {
                Console.WriteLine("OUT");
                Console.WriteLine($"Current Wind Speed {data.WindInfo.Value.Speed}");
                Console.WriteLine($"Current Wind Direction {data.WindInfo.Value.Direction}");
            }

            Console.WriteLine($"Current Temperature {data.Temperature}");
            Console.WriteLine($"Current Humidity {data.Humidity}");
            Console.WriteLine($"Current Pressure {data.Pressure}");
            Console.WriteLine("----------------");
        }
    }
}