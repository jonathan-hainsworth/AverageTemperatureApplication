﻿using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperatureSourceB
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);
    }
}
