using System.Text.Json;
using AspireSample.Database;
using AspireSample.Database.Weather;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

namespace AspireSample.ApiService.Weather;

public interface IWeatherRepository
{
    Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync();
}

public class WeatherCachedRepository : IWeatherRepository
{
    private readonly WeatherDatabaseRepository _database;
    private readonly IConnectionMultiplexer _cache;

    public WeatherCachedRepository(WeatherDatabaseRepository database, IConnectionMultiplexer cache)
    {
        _database = database;
        _cache = cache;
    }

    public async Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync()
    {
        // 1. Check if the data is in the cache
        var cacheDb = _cache.GetDatabase();
        var cachedData = await cacheDb.StringGetAsync("weather_forecast");
        if (cachedData.HasValue)
        {
            var forecast = JsonSerializer.Deserialize<IEnumerable<WeatherForecastDb>>(cachedData.ToString());
            if (forecast is not null)
            {
                // 2. If it is, return the data
                return forecast;
            }
        }

        // 3. If it is not, get the data from the database
        var sqlData = await _database.GetWeatherForecastAsync();
        
        // 4. Save the data to the cache
        var json = JsonSerializer.Serialize(sqlData);
        await cacheDb.StringSetAsync("weather_forecast", json);
        
        return sqlData;
    }
}

public class WeatherDatabaseRepository : IWeatherRepository
{
    private readonly WeatherContext _context;

    public WeatherDatabaseRepository(WeatherContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync()
    {
        return await _context.Weather.ToListAsync();
    }
}
