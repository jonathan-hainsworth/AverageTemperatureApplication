using AverageTemperatureApplication.DAL.Interfaces;
using Models;
using System.Net;

namespace AverageTemperatureApplication.DAL.Impementations
{
    public class AverageTemperatureSource : IAverageTemperatureSource
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay)
        {
            throw new NotImplementedException();
        }
    }
}
