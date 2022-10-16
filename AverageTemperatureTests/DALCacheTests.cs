using AverageTemperatureApplication.DAL.Impementations;
using AverageTemperatureApplication.Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace AverageTemperatureTests
{
    public class DALCacheTests
    {
        private Mock<AverageTemperatureContext> _averageTemperatureDBContext = new Mock<AverageTemperatureContext>();

        [Test]
        public void SuccesfullyGetDataFromCache()
        {
            // Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            DateOnly endDate = new DateOnly(2022,10,15);
            DateOnly startDate = new DateOnly(2022, 10, 10);

            var DalResponse = new AverageTemperature
            {
                Temperature = 5.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = startDate,
                EndDay = endDate,
                isSuccessfull = true,
            };

            /*_averageTemperatureDBContext.Setup(x => x.Set<CachedTemperatures>).Returns(
                    new CachedTemperatures
                    {
                        Temperature = 10.2
                    }
                );*/

            var mockInstance = new AverageTemperateCache(_averageTemperatureDBContext.Object);

            // Assert
            var result = mockInstance.GetAverageTemperature(latitude, longitude, endDate);

            // Act
            Debug.Assert(result.Result.Temperature==5.5);
        }

        [Test]
        public void UnsuccesfullyGetDataFromCache()
        {
            // Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            DateOnly endDate = new DateOnly(2022, 10, 15);

            var DalResponse = new AverageTemperature
            {
                Temperature = 5.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5)),
                isSuccessfull = false,
            };

            var mockInstance = new AverageTemperateCache(_averageTemperatureDBContext.Object);

            // Assert
            var result = mockInstance.GetAverageTemperature(latitude, longitude, endDate);

            // Act
            Debug.Assert(false);
        }
    }
}
