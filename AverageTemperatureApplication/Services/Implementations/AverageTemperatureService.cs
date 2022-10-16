using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Interfaces;
using Models;

namespace AverageTemperatureApplication.Services.Implementations
{
    public class AverageTemperatureService : IAverageTemperatureService
    {
        private readonly IAverageTemperateCache _averageTemperateCache;
        private readonly IAverageTemperatureSource _averageTemperatureSourceA;

        public AverageTemperatureService(
            IAverageTemperateCache averageTemperateCache,
            IAverageTemperatureSource averageTemperatureSource)
        {
            _averageTemperateCache = averageTemperateCache;
            _averageTemperatureSourceA = averageTemperatureSource;
        }

        public async Task<AverageTemperatureResponse> GetAverageTemperature(double latitude, double longitude)
        {
            throw new NotImplementedException();
        }
    }
}
