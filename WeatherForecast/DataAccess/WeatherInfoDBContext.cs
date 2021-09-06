using Microsoft.EntityFrameworkCore;
using WeatherForecast.Models;

namespace WeatherForecast.DataAccess
{
    public class WeatherInfoDBContext : DbContext
    {
        public WeatherInfoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Rain7Dayinfo> RainInfo { get; set; }
        public DbSet<DeviceInfo> Weather { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            ////    builder.Entity<DeviceInfo>().ToTable("Device");
            //var converter = new ValueConverter<List<double>, double>();

            builder.Entity<Rain7Dayinfo>()
                            .Ignore(e => e.Vals);
            //builder.Entity<Rain7Dayinfo>()
            //.HasOne(i => i.Name)
            //             .WithOne()
            //             .HasForeignKey(i => i.Name)
            //             .OnDelete(DeleteBehavior.Cascade);
            //builder.Entity<Device>()
            //.HasMany(i => i.DeviceInformation)
            //             .WithOne(s=>s.Rain7DayInfo)
            //             .HasForeignKey<DeviceInfo>(i => i.)
            //             .OnDelete(DeleteBehavior.Cascade);
            builder
       .Entity<DeviceInfo>()
       .HasOne(x => x.Rain7DayInfo)
       .WithOne(x => x.DeviceInfo)
       .HasForeignKey<Rain7Dayinfo>(c => c.Name)
       .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(builder);
        }
    }
}