using AverageTemperatureApplication.DAL.Impementations;
using Models;
using NUnit.Framework;
using System;
using System.Diagnostics;

namespace AverageTemperatureTests
{
    public class DALSourceATests
    {
        [Test]
        public void SuccesfullyGetDataFromSourceA()
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
                isSuccessfull = true,
                isRequestLimitReached = false
            };

            // Assert
            var result = new AverageTemperatureSourceA().GetAverageTemperature(latitude, longitude, endDate);

            // Act
            Debug.Assert(false);
        }

        [Test]
        public void UnsuccesfullyGetDataFromSourceA()
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
                isRequestLimitReached = false
            };

            // Assert
            var result = new AverageTemperatureSourceA().GetAverageTemperature(latitude, longitude, endDate);

            // Act
            Debug.Assert(false);
        }
    }
}
