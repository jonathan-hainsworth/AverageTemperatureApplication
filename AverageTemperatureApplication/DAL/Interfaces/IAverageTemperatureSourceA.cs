using Models;

namespace AverageTemperatureApplication.DAL.Interfaces
{
    public interface IAverageTemperatureSourceA
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay);
    }
}
