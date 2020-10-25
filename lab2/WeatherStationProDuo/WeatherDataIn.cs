namespace WeatherStationProDuo
{
    public class WeatherDataIn : Observable<WeatherInfo>
    {
        private double _humidity;
        private double _pressure;
        private double _temperature;

        private void MeasurementsChanged()
        {
            NotifyObservers();
        }

        public void SetMeasurements(double temp, double humidity, double pressure)
        {
            _humidity = humidity;
            _temperature = temp;
            _pressure = pressure;

            MeasurementsChanged();
        }

        protected override WeatherInfo GetChangedData()
        {
            WeatherInfo info;
            info.Temperature = _temperature;
            info.Humidity = _humidity;
            info.Pressure = _pressure;
            info.WindInfo = null;
            return info;
        }
    }
}