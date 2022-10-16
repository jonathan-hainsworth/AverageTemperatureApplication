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

        /*[TestInitialize]
        public void SetUp()
        {
            _averageTemperateCache = new Mock<IAverageTemperateCache>();
            _averageTemperatureSource = new Mock<IAverageTemperatureSource>();
        }*/

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
                Temperature = 5.5,
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
            var result = mockInstance.GetAverageTemperature(latitude, longitude);

            //Act
            Assert.IsTrue(result.Result.Temperature == (double) 5.5);
            Debug.Assert(result.Result.Latitude == latitude);
            Debug.Assert(result.Result.Longitude == longitude);
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
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isSuccessfull = false
            };
            _averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(cacheResponse));

            // dataSource
            var dataSourceAResponse = new AverageTemperature
            {
                Temperature = 2.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isSuccessfull = true
            };
            _averageTemperatureSource.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(),
                It.IsAny<double>(),
                It.IsAny<DateOnly>())).Returns(Task.FromResult(dataSourceAResponse));


            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);

            //Assert
            var result = instance.GetAverageTemperature(latitude, longitude);

            //Act
            Debug.Assert(result.Result.Temperature == 2.5);
            Debug.Assert(result.Result.Latitude == latitude);
            Debug.Assert(result.Result.Longitude == longitude);
        }

        // note: this should be private
        /*[Test]
        public void getDateOnlyNowTest()
        {
            //Arrange
            var instance = new AverageTemperatureService(
                _averageTemperateCache.Object,
                _averageTemperatureSource.Object);
            //Act
            DateOnly dateOnly = instance.getDateOnlyNow();
            //Assert
            Console.WriteLine(dateOnly);
            Console.WriteLine(dateOnly);
        }*/
    }
}