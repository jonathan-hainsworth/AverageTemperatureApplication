using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Interfaces;
using Models;

namespace AverageTemperatureApplication.Services.Implementations
{
    public class AverageTemperatureService : IAverageTemperatureService
    {
        private IAverageTemperateCache _averageTemperateCache;
        private IAverageTemperatureSourceA _averageTemperatureSourceA;
        private IAverageTemperatureSourceB _averageTemperatureSourceB;

        public AverageTemperatureService(
            IAverageTemperateCache averageTemperateCache,
            IAverageTemperatureSourceA averageTemperatureSourceA,
            IAverageTemperatureSourceB averageTemperatureSourceB)
        {
            _averageTemperateCache = averageTemperateCache;
            _averageTemperatureSourceA = averageTemperatureSourceA;
            _averageTemperatureSourceB = averageTemperatureSourceB;
        }

        public AverageTemperature getAverageTemperature()
        {
            throw new NotImplementedException();
        }
    }
}
