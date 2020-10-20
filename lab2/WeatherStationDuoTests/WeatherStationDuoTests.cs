using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherStationDuo;

namespace WeatherStationDuoTests
{
    internal class DisplayTest : WeatherStationDuo.IObserver<WeatherInfo>
    {
        private readonly WeatherData _weatherDataIn;
        private readonly WeatherData _weatherDataOut;

        public DisplayTest(WeatherData weatherDataIn, WeatherData weatherDataOut)
        {
            _weatherDataIn = weatherDataIn;
            _weatherDataOut = weatherDataOut;
        }

        public void Update(WeatherInfo data, WeatherStationDuo.IObservable<WeatherInfo> observable)
        {
            if (_weatherDataIn == observable) Console.Write("IN,");
            if (_weatherDataOut == observable) Console.Write("OUT,");
        }
    }

    [TestClass]
    public class WeatherStationDuoTest
    {
        [TestMethod]
        public void NotifyObservers_WithWeatherStationType()
        {
            var wdIn = new WeatherData();
            var wdOut = new WeatherData();

            var display = new DisplayTest(wdIn, wdOut);

            wdIn.RegisterObserver(display, 1);
            wdOut.RegisterObserver(display, 1);

            var sw = new StringWriter();
            Console.SetOut(sw);
            Console.SetError(sw);

            wdIn.SetMeasurements(3, 0.7, 760);
            wdOut.SetMeasurements(4, 0.8, 761);

            var result = sw.ToString();
            const string expectedResult = "IN,OUT,";

            Assert.AreEqual(expectedResult, result);
        }
    }
}