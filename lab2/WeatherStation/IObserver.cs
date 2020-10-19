namespace WeatherStation
{
    public interface IObserver<T>
    {
        void Update(T data);
    }
}