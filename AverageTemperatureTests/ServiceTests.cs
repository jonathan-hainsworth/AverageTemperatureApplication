using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Implementations;
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
        private Mock<IAverageTemperateCache> _averageTemperateCache = new Mock<IAverageTemperateCache>();
        private Mock<IAverageTemperatureSource> _averageTemperatureSource = new Mock<IAverageTemperatureSource>();

        [Test]
        public void GetAverageTemperatureFromCache()
        {
            //Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            DateOnly endDate = new DateOnly(2022, 10, 15);
            DateOnly startDate = new DateOnly(2022, 10, 10);

            var cachedAverageTemperature = new AverageTemperature
            {
                Temperature = (double) 5.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = true
            };

            _averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).ReturnsAsync(cachedAverageTemperature);

            var mockInstance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);

            //Assert
            Task<AverageTemperatureResponse?> result = mockInstance.GetAverageTemperature(latitude, longitude);

            //Act
            Debug.Assert(result.Result.Latitude == latitude);
            Debug.Assert(result.Result.Longitude == longitude);
            Debug.Assert(result.Result.Temperature == (double) 5.5);
        }

        [Test]
        public void GetAverageTemperatureFromDataSource()
        {
            //Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            DateOnly endDate = new DateOnly(2022, 10, 15);
            DateOnly startDate = new DateOnly(2022, 10, 10);

            // cache
            var cacheResponse = new AverageTemperature
            {
                Temperature = 1.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = false
            };
            _averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(cacheResponse));

            // dataSource
            var dataSourceResponse = new AverageTemperature
            {
                Temperature = 2.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = true
            };
            _averageTemperatureSource.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(dataSourceResponse));


            var mockInstance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);

            //Assert
            Task<AverageTemperatureResponse?> result = mockInstance.GetAverageTemperature(latitude, longitude);

            //Act
            Debug.Assert(result.Result.Latitude == latitude);
            Debug.Assert(result.Result.Longitude == longitude);
            Debug.Assert(result.Result.Temperature == 2.5);
        }

        [Test]
        public void UnableToGetDataFromCacheOrSource()
        {
            //Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            DateOnly endDate = new DateOnly(2022, 10, 15);
            DateOnly startDate = new DateOnly(2022, 10, 10);

            // cache
            var cacheResponse = new AverageTemperature
            {
                Temperature = 1.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = false
            };
            _averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(cacheResponse));

            // dataSource
            var dataSourceResponse = new AverageTemperature
            {
                Temperature = 2.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = false
            };
            _averageTemperatureSource.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(dataSourceResponse));

            var mockInstance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);

            //Assert
            Task<AverageTemperatureResponse?> result = mockInstance.GetAverageTemperature(latitude, longitude);

            //Act
            Debug.Assert(result.Result == null);
        }
    }
}