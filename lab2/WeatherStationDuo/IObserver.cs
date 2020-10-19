namespace WeatherStationDuo
{
    public interface IObserver<T>
    {
        void Update(T data, IObservable<T> observable);
    }
}