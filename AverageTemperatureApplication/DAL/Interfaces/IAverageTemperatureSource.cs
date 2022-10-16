using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperatureSource
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);
    }
}
