using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Database;
using Models;

namespace AverageTemperatureApplication.DAL.Impementations
{
    public class AverageTemperateCache : IAverageTemperateCache
    {
        public async Task<AverageTemperature> GetAverageTemperature(double latitude, double longitude, DateOnly EndDay)
        {
            throw new NotImplementedException();
        }

        public void Task<CacheAverageTemperature>(AverageTemperature averageTemperature)
        {
            throw new NotImplementedException();
        }
    }
}
