namespace WeatherStation
{
    public class WeatherData : Observable<WeatherInfo>
    {
        private double _temperature;
        private double _humidity;
        private double _pressure;

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
            return info;
        }
    }
}