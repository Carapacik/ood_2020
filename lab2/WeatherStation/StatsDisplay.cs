using System;

namespace WeatherStation
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly AdditionalStatistic _humidity = new AdditionalStatistic();
        private readonly AdditionalStatistic _pressure = new AdditionalStatistic();
        private readonly AdditionalStatistic _temperature = new AdditionalStatistic();

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

        private static string GetAdditionalStatistics(AdditionalStatistic data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }
    }
}