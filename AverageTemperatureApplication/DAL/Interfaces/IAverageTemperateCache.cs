using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperateCache
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);
    }
}
