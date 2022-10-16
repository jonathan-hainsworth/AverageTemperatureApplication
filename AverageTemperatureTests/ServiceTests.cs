using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AverageTemperatureTests
{
    [TestFixture]
    public class ServiceTests
    {
        private Mock<Task<IAverageTemperateCache>> _averageTemperateCache = new Mock<Task<IAverageTemperateCache>>();
        private Mock<Task<IAverageTemperatureSource>> _averageTemperatureSource = new Mock<Task<IAverageTemperatureSource>>();

        /*[TestInitialize]
        public void SetUp()
        {
            _averageTemperateCache = new Mock<Task<IAverageTemperateCache>>();
            _averageTemperatureSource = new Mock<Task<IAverageTemperatureSource>>();
        }*/

        [Test]
        public void GetAverageTemperatureFromCache()
        {
            //Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            Guid apiKey = Guid.NewGuid();

            var cacheResponse = new AverageTemperature
            {
                Temperature = 5.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isRequestLimitReached = false,
                isSuccessfull = true
            };


            /*_averageTemperatureSource.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).ReturnAsync(cacheResponse);

            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);*/

            //Assert
            //var result = instance.GetAverageTemperature(latitude, longitude, apiKey);

            //Act
            /*Debug.Assert(result.Temperature == 5.5);
            Debug.Assert(result.Latitude == latitude);
            Debug.Assert(result.Longitude == longitude);*/
        }

        [Test]
        public void GetAverageTemperatureFromDataSourceA()
        {
            //Arrange
            /*double latitude = 55.9486;
            double longitude = 3.1999;
            Guid apiKey = Guid.NewGuid();

            // cache
            var cacheResponse = new AverageTemperature
            {
                Temperature = 1.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isRequestLimitReached = false,
                isSuccessfull = false
            };
            _averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).ReturnAsync(cacheResponse);

            // dataSourceA
            var dataSourceAResponse = new AverageTemperature
            {
                Temperature = 2.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isRequestLimitReached = false,
                isSuccessfull = true
            };
            _averageTemperatureSource.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(dataSourceAResponse);


            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);

            //Assert
            var result = instance.GetAverageTemperature(latitude, longitude, apiKey);

            //Act
            Debug.Assert(result.Temperature == 2.5);
            Debug.Assert(result.Latitude == latitude);
            Debug.Assert(result.Longitude == longitude);*/
        }
    }
}