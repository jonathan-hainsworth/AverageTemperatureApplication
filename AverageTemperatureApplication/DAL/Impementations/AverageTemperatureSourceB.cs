using AverageTemperatureApplication.DAL.Interfaces;
using Models;

namespace AverageTemperatureApplication.DAL.Impementations
{
    public class AverageTemperatureSourceB : IAverageTemperatureSourceB
    {
        public AverageTemperature GetAverageTemperature(double latitude, double longitude, DateOnly EndDay)
        {
            throw new NotImplementedException();
        }
    }
}
