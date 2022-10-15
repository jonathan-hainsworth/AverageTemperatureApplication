using Microsoft.EntityFrameworkCore;

namespace AverageTemperatureApplication.Database
{
    public class AverageTemperatureContext : DbContext
    {
        public AverageTemperatureContext(DbContextOptions<AverageTemperatureContext> options) : base(options)
        {

        }

        public DbSet<CachedTemperatures> CachedTemperatures { get; set; }
        public DbSet<UserApiKeys> UserApiKeys { get; set; }
    }
}
