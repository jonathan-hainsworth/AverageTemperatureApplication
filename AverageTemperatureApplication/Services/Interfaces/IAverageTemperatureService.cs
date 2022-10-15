using Models;

namespace AverageTemperatureApplication.Services.Interfaces
{
    public interface IAverageTemperatureService
    {
        public AverageTemperatureResponse GetAverageTemperature(double latitude, double longitude, Guid apiKey);
    }
}
