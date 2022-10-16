using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Services.Interfaces;
using Models;

namespace AverageTemperatureApplication.Services.Implementations
{
    public class AverageTemperatureService : IAverageTemperatureService
    {
        private readonly IAverageTemperateCache _averageTemperateCache;
        private readonly IAverageTemperatureSource _averageTemperatureSource;

        public AverageTemperatureService(
            IAverageTemperateCache averageTemperateCache,
            IAverageTemperatureSource averageTemperatureSource)
        {
            _averageTemperateCache = averageTemperateCache;
            _averageTemperatureSource = averageTemperatureSource;
        }

        public async Task<AverageTemperatureResponse?> GetAverageTemperature(double latitude, double longitude)
        {
            DateOnly dateOnly = getDateOnlyNow();

            AverageTemperature fiveDaysAverageTemperature;

            fiveDaysAverageTemperature = await _averageTemperateCache.GetAverageTemperature(latitude, longitude, dateOnly);

            if(fiveDaysAverageTemperature == null)
            {
                fiveDaysAverageTemperature = await _averageTemperateCache.GetAverageTemperature(latitude, longitude, dateOnly);
            }
            else
            {
                return convertToResponse(fiveDaysAverageTemperature);
            }

            if (fiveDaysAverageTemperature == null)
            {
                return null;
            }
            else
            {
                _averageTemperateCache.CacheAverageTemperature(fiveDaysAverageTemperature);
            }

            return convertToResponse(fiveDaysAverageTemperature);
        }

        // note: this should be private
        public DateOnly getDateOnlyNow()
        {
            DateTime now = DateTime.Now;
            return new DateOnly(now.Year, now.Month, now.Day);
        }

        private AverageTemperatureResponse convertToResponse(AverageTemperature averageTemperature)
        {
            return new AverageTemperatureResponse
            {   
                StartDay = averageTemperature.StartDay,
                EndDay = averageTemperature.EndDay,
                Latitude = averageTemperature.Latitude,
                Longitude = averageTemperature.Longitude
            };
        }
    }
}
