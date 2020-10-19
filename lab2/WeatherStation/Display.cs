using System;

namespace WeatherStation
{
    public class Display : IObserver<WeatherInfo>
    {
        public void Update(WeatherInfo data)
        {
            Console.WriteLine($"Current Temperature {data.Temperature}");
            Console.WriteLine($"Current Humidity {data.Humidity}");
            Console.WriteLine($"Current Pressure {data.Pressure}");
            Console.WriteLine("----------------");
        }
    }
}