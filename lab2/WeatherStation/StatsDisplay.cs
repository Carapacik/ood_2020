using System;

namespace WeatherStation
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly AdditionalStatistics _temperature = new AdditionalStatistics();
        private readonly AdditionalStatistics _humidity = new AdditionalStatistics();
        private readonly AdditionalStatistics _pressure = new AdditionalStatistics();

        private static string GetAdditionalStatistics(AdditionalStatistics data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }

        public void Update(WeatherInfo data)
        {
            _temperature.UpdateData(data.Temperature);
            _humidity.UpdateData(data.Humidity);
            _pressure.UpdateData(data.Pressure);

            Console.WriteLine($"Temperature: {GetAdditionalStatistics(_temperature)}");
            Console.WriteLine($"Humidity: {GetAdditionalStatistics(_humidity)}");
            Console.WriteLine($"Pressure: {GetAdditionalStatistics(_pressure)}");
            Console.WriteLine("----------------");
        }
    }
}