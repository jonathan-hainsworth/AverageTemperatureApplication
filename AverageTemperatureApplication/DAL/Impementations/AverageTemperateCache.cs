using AverageTemperatureApplication.DAL.Interfaces;
using AverageTemperatureApplication.Database;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AverageTemperatureApplication.DAL.Impementations
{
    public class AverageTemperateCache : IAverageTemperateCache
    {
        private AverageTemperatureContext _averageTemperatureContext;

        public AverageTemperateCache(AverageTemperatureContext averageTemperatureContext)
        {
            _averageTemperatureContext = averageTemperatureContext;
        }

        public async Task<AverageTemperature> GetAverageTemperature(double latitude, double longitude, DateOnly endDay)
        {
            var result = await _averageTemperatureContext.CachedTemperatures.Where(
                c => c.Latitude == latitude && c.Longitude == longitude && c.Day == DayOnlyToDateTime(endDay)).FirstOrDefaultAsync();

            if(result == null)
            {
                return new AverageTemperature(){
                    isSuccessfull = false
                };
            }
            return CacheToAverageTemperatesIsSuccessful(result);
        }

        public async void CacheAverageTemperature(AverageTemperature averageTemperature)
        {
            throw new NotImplementedException();
        }

        private AverageTemperature CacheToAverageTemperatesIsSuccessful(CachedTemperatures cachedTemperatures)
        {
            return new AverageTemperature()
            {
                Temperature = cachedTemperatures.Temperature,
                EndDay = DateTimeToDayOnly(cachedTemperatures.Day),
                Latitude = cachedTemperatures.Latitude,
                Longitude = cachedTemperatures.Longitude,
                isSuccessfull = true
            };
        }

        private static DateTime DayOnlyToDateTime(DateOnly endDay)
        {
            return new DateTime(endDay.Year, endDay.Month, endDay.Day);
        }

        private static DateOnly DateTimeToDayOnly(DateTime endDay)
        {
            return new DateOnly(endDay.Year, endDay.Month, endDay.Day);
        }
    }
}
