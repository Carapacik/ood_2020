using System;

namespace WeatherStationPro
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly AdditionalStatistics _temperatureData = new AdditionalStatistics();
        private readonly AdditionalStatistics _humidityData = new AdditionalStatistics();
        private readonly AdditionalStatistics _pressureData = new AdditionalStatistics();
        private readonly AdditionalStatistics _windSpeed = new AdditionalStatistics();
        private readonly WindAdditionalStatistic _windDirection = new WindAdditionalStatistic();

        private static string GetAdditionalStatistics(AdditionalStatistics data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }

        private static string GetDirectionStatistics(WindAdditionalStatistic data)
        {
            return $" AVG direction {data.GetAverageDirectionValue()}";
        }

        public void Update(WeatherInfo data)
        {
            _temperatureData.UpdateData(data.Temperature);
            _humidityData.UpdateData(data.Humidity);
            _pressureData.UpdateData(data.Pressure);
            _windSpeed.UpdateData(data.WindInfo.Speed);
            _windDirection.UpdateData(data.WindInfo.Direction);

            Console.WriteLine($"Temperature: {GetAdditionalStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetAdditionalStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetAdditionalStatistics(_pressureData)}");
            Console.WriteLine($"Wind: {GetAdditionalStatistics(_windSpeed)}");
            Console.WriteLine($"{GetDirectionStatistics(_windDirection)}");
            Console.WriteLine("----------------");
        }
    }
}