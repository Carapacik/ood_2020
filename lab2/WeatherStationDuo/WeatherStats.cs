using  System;

namespace WeatherStationDuo
{
    public class WeatherStats
    {
        private readonly AdditionalStatistics _temperatureData = new AdditionalStatistics();
        private readonly AdditionalStatistics _humidityData = new AdditionalStatistics();
        private readonly AdditionalStatistics _pressureData = new AdditionalStatistics();

        private static string GetAdditionalStatistics(AdditionalStatistics data)
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