using AverageTemperatureApplication.Controllers;
using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AverageTemperatureTests
{
    [TestFixture]
    public class ControllerTests
    {
        private readonly Mock<IAverageTemperatureService> _averageTemperateCache = new Mock<IAverageTemperatureService>();

        [Test]
        public void AverageTemperatureControllerRequestFailedTooManyRequests()
        {
            // Arrange
            double latitude = 55.9486;
            double longitude = 3.1999;
            Guid apiKey = Guid.NewGuid();

            var serviceResponse = new AverageTemperatureResponse
            {
                Temperature = 5.5,
                Latitude = latitude,
                Longitude = longitude,
                StartDay = DateOnly.FromDateTime(new DateTime()),
                EndDay = DateOnly.FromDateTime(new DateTime().AddDays(-5))
            };

            /*_averageTemperateCache.Setup(x => x.GetAverageTemperature(
                It.IsAny<double>(), 
                It.IsAny<double>(),
                It.IsAny<Guid>())).Returns(serviceResponse);*/

            var instance = new AverageTemperatureController(_averageTemperateCache.Object);

            //Assert
            var result = instance.Get(latitude, longitude);

            //Act
            //Assert StatusCode Type
        }
    }
}
