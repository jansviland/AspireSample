using AspireSample.Database.Weather;
using Microsoft.EntityFrameworkCore;

namespace AspireSample.Database;

public abstract class WeatherConfiguration
{
    public static void AddConfiguration(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<WeatherForecastDb>(entity =>
        {
            entity.ToTable("Weather");

            entity.HasKey(e => e.Id);

            entity.Property(e => e.Date).HasColumnType("date");

            entity.Property(e => e.TemperatureC).IsRequired();

            entity.Property(e => e.Summary).HasMaxLength(50);
        });
    }
}
