namespace WeatherStationPro
{
    public class WeatherData : Observable<WeatherInfo>
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
            _wind.Direction = direction;
            _wind.Speed = speed;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info;
            info.Temperature = _temperature;
            info.Humidity = _humidity;
            info.Pressure = _pressure;
            info.WindInfo.Speed = _wind.Speed;
            info.WindInfo.Direction = _wind.Direction;
            return info;
        }
    }
}