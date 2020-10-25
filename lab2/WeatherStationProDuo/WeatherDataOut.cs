namespace WeatherStationProDuo
{
    public class WeatherDataOut : Observable<WeatherInfo>
    {
        private double _humidity;
        private double _pressure;
        private double _temperature;
        private WindInfo _wind;

        private void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(double temp, double humidity, double pressure, double speed, double direction)
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;
            _wind.Speed = speed;
            _wind.Direction = direction;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info;
            info.Temperature = _temperature;
            info.Humidity = _humidity;
            info.Pressure = _pressure;
            info.WindInfo = new WindInfo
            {
                Speed = _wind.Speed,
                Direction = _wind.Direction
            };
            return info;
        }
    }
}