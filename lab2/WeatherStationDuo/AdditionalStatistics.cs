namespace WeatherStationDuo
{
    public class AdditionalStatistics
    {
        private double _min = double.PositiveInfinity;
        private double _max = double.NegativeInfinity;
        private double _acc = 0;
        private uint _countAcc = 0;

        public void UpdateData(double value)
        {
            if (_min > value) _min = value;
            if (_max < value) _max = value;
            _acc += value;
            _countAcc++;
        }

        public double GetMinValue()
        {
            return _min;
        }

        public double GetMaxValue()
        {
            return _max;
        }

        public double GetAverageValue()
        {
            return _acc / _countAcc;
        }
    }
}