namespace WeatherStationPro
{
    public interface IObserver<T>
    {
        void Update(T data);
    }
}