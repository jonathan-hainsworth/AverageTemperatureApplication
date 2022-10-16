using Models;

namespace AverageTemperatureApplication.Services.Interfaces
{
    public interface IAverageTemperatureService
    {
        public Task<AverageTemperatureResponse> GetAverageTemperature(double latitude, double longitude);
    }
}
