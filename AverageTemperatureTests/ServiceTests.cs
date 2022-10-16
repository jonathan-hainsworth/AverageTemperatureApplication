using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Implementations;
using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace AverageTemperatureTests
{
    [TestFixture]
    public class ServiceTests
    {
        private readonly Mock<IAverageTemperateCache> _averageTemperateCache = new Mock<IAverageTemperateCache>();
        private readonly Mock<IAverageTemperatureSource> _averageTemperatureSourceA = new Mock<IAverageTemperatureSource>();
        private readonly Mock<IAverageTemperatureSourceB> _averageTemperatureSourceB = new Mock<IAverageTemperatureSourceB>();

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
            _averageTemperatureSourceA.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(cacheResponse);

            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSourceA.Object,
                _averageTemperatureSourceB.Object);

            //Assert
            var result = instance.GetAverageTemperature(latitude, longitude, apiKey);

            //Act
            Debug.Assert(result.Temperature == 5.5);
            Debug.Assert(result.Latitude == latitude);
            Debug.Assert(result.Longitude == longitude);
        }

        [Test]
        public void GetAverageTemperatureFromDataSourceA()
        {
            //Arrange
            double latitude = 55.9486;
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
                It.IsAny<DateOnly>())).Returns(cacheResponse);

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
            _averageTemperatureSourceA.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(dataSourceAResponse);


            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSourceA.Object,
                _averageTemperatureSourceB.Object);

            //Assert
            var result = instance.GetAverageTemperature(latitude, longitude, apiKey);

            //Act
            Debug.Assert(result.Temperature == 2.5);
            Debug.Assert(result.Latitude == latitude);
            Debug.Assert(result.Longitude == longitude);
        }

        [Test]
        public void GetAverageTemperatureFromDataSourceB()
        {
            //Arrange
            double latitude = 55.9486;
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
                It.IsAny<DateOnly>())).Returns(cacheResponse);

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
            _averageTemperatureSourceA.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(dataSourceAResponse);

            // dataSourceB
            var dataSourceBResponse = new AverageTemperature
            {
                Temperature = 3.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isRequestLimitReached = false,
                isSuccessfull = true
            };
            _averageTemperatureSourceB.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(dataSourceBResponse);

            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSourceA.Object,
                _averageTemperatureSourceB.Object);

            //Assert
            var result = instance.GetAverageTemperature(latitude, longitude, apiKey);

            //Act
            Debug.Assert(result.Temperature == 3.5);
            Debug.Assert(result.Latitude == latitude);
            Debug.Assert(result.Longitude == longitude);
        }
    }
}