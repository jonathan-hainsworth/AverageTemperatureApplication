using Microsoft.EntityFrameworkCore;

namespace AverageTemperatureApplication.Database
{
    public class AverageTemperatureContext : DbContext
    {
        public AverageTemperatureContext(DbContextOptions<AverageTemperatureContext> options) : base(options)
        {

        }

        public virtual DbSet<CachedTemperatures> CachedTemperatures { get; set; }
    }
}
