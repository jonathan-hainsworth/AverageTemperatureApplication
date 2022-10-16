using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperateCache
    {
        public Task<AverageTemperature> GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);

        public void CacheAverageTemperature(AverageTemperature averageTemperature);
    }
}
