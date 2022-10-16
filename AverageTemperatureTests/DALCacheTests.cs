using AverageTemperatureApplication.DAL.Impementations;
using AverageTemperatureApplication.Database;
using Microsoft.EntityFrameworkCore;
using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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
            DateTime endDate = new DateTime(2022,10,15);
            DateOnly dateOnlyendDate = new DateOnly(2022, 10, 15);
            DateOnly startDate = new DateOnly(2022, 10, 10);

            var data = new List<CachedTemperatures>
            {
                new CachedTemperatures
                {
                    Temperature = 5.5,
                    Latitude = latitude,
                    Longitude = longitude,
                    Day = endDate
                }
            }.AsQueryable();

            Mock<DbSet<CachedTemperatures>> mockSet = new Mock<DbSet<CachedTemperatures>>();
            mockSet.As<IQueryable<CachedTemperatures>>().Setup(x => x.Expression).Returns(data.Expression);

            Mock<AverageTemperatureContext> mockContext = new Mock<AverageTemperatureContext>();
            mockContext.Setup(c => c.CachedTemperatures).Returns(mockSet.Object);

            var service = new AverageTemperateCache(mockContext.Object); // error here
            var result = service.GetAverageTemperature(latitude, longitude, dateOnlyendDate);

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
