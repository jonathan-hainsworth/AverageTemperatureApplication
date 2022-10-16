using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Interfaces;
using Models;

namespace AverageTemperatureApplication.Services.Implementations
{
    public class AverageTemperatureService : IAverageTemperatureService
    {
        private IAverageTemperateCache _averageTemperateCache;
        private IAverageTemperatureSource _averageTemperatureSourceA;

        public AverageTemperatureService(
            IAverageTemperateCache averageTemperateCache,
            IAverageTemperatureSource averageTemperatureSourceA)
        {
            _averageTemperateCache = averageTemperateCache;
            _averageTemperatureSourceA = averageTemperatureSourceA;
        }

        public async Task<AverageTemperatureResponse> GetAverageTemperature(double latitude, double longitude, Guid apiKey)
        {
            throw new NotImplementedException();
        }
    }
}
