using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStation;

namespace WeatherStationTests
{
    [TestClass]
    public class ObserverTest : WeatherStation.IObserver<WeatherInfo>
    {
        private readonly int _priority;

        public ObserverTest(int priority)
        {
            _priority = priority;
        }

        public void Update(WeatherInfo data)
        {
            Console.Write($"priority - {_priority};");
        }
    }
    
    [TestClass]
    public class PriorityTests
    {
        [TestMethod]
        public void ObserverNotifyInCorrectPriority_ReturnPriorityInDescFormat()
        {
            var weatherData = new WeatherData();
            var obs2 = new ObserverTest(2);
            var obs4 = new ObserverTest(4);
            var obs8 = new ObserverTest(8);
            var obs0 = new ObserverTest(0);

            weatherData.RegisterObserver(obs2, 2);
            weatherData.RegisterObserver(obs4, 4);
            weatherData.RegisterObserver(obs8, 8);
            weatherData.RegisterObserver(obs0, 0);

            var output = new StringWriter();
            Console.SetOut(output);
            Console.SetError(output);
            weatherData.SetMeasurements(1, 0.1, 500);
            const string expectedResult = "priority - 8;priority - 4;priority - 2;priority - 0;";

            Assert.AreEqual(expectedResult, output.ToString());
        }
    }
    
    public class UpdateTest : WeatherStation.IObserver<WeatherInfo>
    {
        private readonly WeatherStation.IObservable<WeatherInfo> _observable;

        public UpdateTest(WeatherStation.IObservable<WeatherInfo> observable)
        {
            _observable = observable;
        }

        public void Update(WeatherInfo data)
        {
            _observable.RemoveObserver(this);
        }
    }
    
    [TestClass]
    public class RemoveObserverFromUpdateTest
    {
        [TestMethod]
        public void RemoveObserverFromUpdate_DoNotException()
        {
            WeatherData wd = new WeatherData();
            UpdateTest updateTest = new UpdateTest(wd);

            wd.RegisterObserver(updateTest, 1);
            wd.SetMeasurements(3, 0.7, 760);
        }
    }
    
 
}