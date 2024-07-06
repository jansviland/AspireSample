using AspireSample.Database.Weather;
using Microsoft.EntityFrameworkCore;

namespace AspireSample.Database;

public  class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
        
    }
    
    public DbSet<WeatherForecastDb> Weather { get; set; }
    
}
