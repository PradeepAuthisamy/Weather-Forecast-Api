using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace WeatherForecast.DataAccess
{
    public class WeatherInfoDBContext : DbContext
    {
        public WeatherInfoDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Weather> Weather { get; set; }
    }
}