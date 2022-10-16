using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperatureSource
    {
        public Task<AverageTemperature> GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);
    }
}
