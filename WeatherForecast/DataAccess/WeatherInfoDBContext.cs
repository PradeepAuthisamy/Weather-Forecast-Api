using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;

namespace WeatherForecast.DataAccess
{
    public class WeatherInfoDBContext : DbContext
    {
        public WeatherInfoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<DeviceInfo> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ////    builder.Entity<DeviceInfo>().ToTable("Device");
            //var converter = new ValueConverter<List<double>, double>();

            builder.Entity<Rain7Dayinfo>()
                            .Ignore(e => e.Vals);
            base.OnModelCreating(builder);
        }
    }
}