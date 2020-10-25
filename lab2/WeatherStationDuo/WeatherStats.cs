using System;

namespace WeatherStationDuo
{
    public class WeatherStats
    {
        private readonly AdditionalStatistic _humidityData = new AdditionalStatistic();
        private readonly AdditionalStatistic _pressureData = new AdditionalStatistic();
        private readonly AdditionalStatistic _temperatureData = new AdditionalStatistic();

        private static string GetAdditionalStatistics(AdditionalStatistic data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }

        public void PrintStatistics(WeatherInfo data)
        {
            _temperatureData.UpdateData(data.Temperature);
            _humidityData.UpdateData(data.Humidity);
            _pressureData.UpdateData(data.Pressure);

            Console.WriteLine($"Temperature: {GetAdditionalStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetAdditionalStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetAdditionalStatistics(_pressureData)}");
            Console.WriteLine("----------------");
        }
    }
}