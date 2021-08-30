using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.DataAccess
{
    public class WeatherInfoDBContext : DbContext
    {
        public WeatherInfoDBContext(DbContextOptions options) : base(options)
        {
        }

        //public DbSet<Weather> Weather { get; set; }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Weather>().ToTable("Weather");
        //    builder.Entity<Geo>().ToTable("Geo");
        //}
    }
}