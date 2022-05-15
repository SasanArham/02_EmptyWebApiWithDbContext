using Microsoft.EntityFrameworkCore;

namespace EmptyWebApiWithDbContext
{


    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> opt) : base(opt)
        {

        }

        public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    }
}