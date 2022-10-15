using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Database;
using Models;

namespace AverageTemperatureApplication.DAL.Impementations
{
    public class AverageTemperateCache : IAverageTemperateCache
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay)
        {
            throw new NotImplementedException();
        }
    }
}
