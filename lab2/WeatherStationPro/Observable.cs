using System.Collections.Generic;
using System.Linq;

namespace WeatherStationPro
{
    public abstract class Observable<T> : IObservable<T>
    {
        private List<(IObserver<T>, int)> _observers = new List<(IObserver<T>, int)>();

        public void RegisterObserver(IObserver<T> observer, int priority)
        {
            _observers.Add((observer, priority));
            _observers = _observers.OrderByDescending(o => o.Item2).ToList();
        }

        public void RemoveObserver(IObserver<T> observer)
        {
            _observers.RemoveAll(o => o.Item1 == observer);
        }

        public void NotifyObservers()
        {
            T data = GetChangedData();
            foreach (var observer in _observers.ToList()) observer.Item1.Update(data);
        }

        protected abstract T GetChangedData();
    }
}