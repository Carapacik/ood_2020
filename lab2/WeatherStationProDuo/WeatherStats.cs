using System;

namespace WeatherStationProDuo
{
    public class WeatherStats
    {
        private readonly AdditionalStatistic _humidityData = new AdditionalStatistic();
        private readonly AdditionalStatistic _pressureData = new AdditionalStatistic();
        private readonly AdditionalStatistic _temperatureData = new AdditionalStatistic();
        private readonly DirectionAdditionalStatistic _windDirection = new DirectionAdditionalStatistic();
        private readonly AdditionalStatistic _windSpeed = new AdditionalStatistic();

        private static string GetAdditionalStatistics(AdditionalStatistic data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }

        private static string GetDirectionAdditionalStatistics(DirectionAdditionalStatistic data)
        {
            return $" AVG Dir {data.GetAverageDirectionValue()}";
        }

        private void UpdateStatistics(WeatherInfo data)
        {
            _temperatureData.UpdateData(data.Temperature);
            _humidityData.UpdateData(data.Humidity);
            _pressureData.UpdateData(data.Pressure);
        }

        private void UpdateWindStatistics(WeatherInfo data)
        {
            _windSpeed.UpdateData(data.WindInfo.Value.Speed);
            _windDirection.UpdateData(data.WindInfo.Value.Direction);
        }

        public void PrintStatistics(WeatherInfo data)
        {
            UpdateStatistics(data);

            Console.WriteLine($"Temperature: {GetAdditionalStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetAdditionalStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetAdditionalStatistics(_pressureData)}");

            if (data.WindInfo != null)
            {
                UpdateWindStatistics(data);

                Console.WriteLine($"Wind: {GetAdditionalStatistics(_windSpeed)}");
                Console.WriteLine($"{GetDirectionAdditionalStatistics(_windDirection)}");
            }

            Console.WriteLine("----------------");
        }
    }
}