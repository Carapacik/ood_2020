using System;

namespace WeatherStationPro
{
    public class StatsDisplay : IObserver<WeatherInfo>
    {
        private readonly DirectionAdditionalStatistic _directionDirection = new DirectionAdditionalStatistic();
        private readonly AdditionalStatistic _humidityData = new AdditionalStatistic();
        private readonly AdditionalStatistic _pressureData = new AdditionalStatistic();
        private readonly AdditionalStatistic _temperatureData = new AdditionalStatistic();
        private readonly AdditionalStatistic _windSpeed = new AdditionalStatistic();

        public void Update(WeatherInfo data)
        {
            _temperatureData.UpdateData(data.Temperature);
            _humidityData.UpdateData(data.Humidity);
            _pressureData.UpdateData(data.Pressure);
            _windSpeed.UpdateData(data.WindInfo.Speed);
            _directionDirection.UpdateData(data.WindInfo.Direction);

            Console.WriteLine($"Temperature: {GetAdditionalStatistics(_temperatureData)}");
            Console.WriteLine($"Humidity: {GetAdditionalStatistics(_humidityData)}");
            Console.WriteLine($"Pressure: {GetAdditionalStatistics(_pressureData)}");
            Console.WriteLine($"Wind: {GetAdditionalStatistics(_windSpeed)}");
            Console.WriteLine($"{GetDirectionStatistics(_directionDirection)}");
            Console.WriteLine("----------------");
        }

        private static string GetAdditionalStatistics(AdditionalStatistic data)
        {
            return $"\n MAX {data.GetMaxValue()}\n MIN {data.GetMinValue()}\n AVG {data.GetAverageValue()}";
        }

        private static string GetDirectionStatistics(DirectionAdditionalStatistic data)
        {
            return $" AVG Dir {data.GetAverageDirectionValue()}";
        }
    }
}