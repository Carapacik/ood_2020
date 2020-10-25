namespace WeatherStationDuo
{
    public class AdditionalStatistic
    {
        private double _acc;
        private uint _countAcc;
        private double _max = double.NegativeInfinity;
        private double _min = double.PositiveInfinity;

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