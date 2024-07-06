using Microsoft.EntityFrameworkCore;

namespace AspireSample.Database;

public  class WeatherContext : DbContext
{
    public WeatherContext(DbContextOptions<WeatherContext> options) : base(options)
    {
        
    }
    
    public DbSet<WeatherDb> Weather { get; set; }
    
}
