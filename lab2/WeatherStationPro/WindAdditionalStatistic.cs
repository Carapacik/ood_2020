using System;

namespace WeatherStationPro
{
    public class WindAdditionalStatistic
    {
        private double _sinSum = 0;
        private double _cosSum = 0;
        private uint _countAcc = 0;

        private static double ConvertDegreesToRadians(double degrees)
        {
            return (Math.PI / 180) * degrees;
        }

        private static double ConvertRadiansToDegrees(double radians)
        {
            return (180 / Math.PI) * radians;
        }

        public void UpdateData(double value)
        {
            _sinSum += Math.Sin(ConvertDegreesToRadians(value));
            _cosSum += Math.Cos(ConvertDegreesToRadians(value));
            _countAcc++;
        }

        public double GetAverageDirectionValue()
        {
            var averageDirection = (ConvertRadiansToDegrees(Math.Atan2(_sinSum / _countAcc, _cosSum / _countAcc)) + 360) % 360;
            return averageDirection;
        }
    }
}