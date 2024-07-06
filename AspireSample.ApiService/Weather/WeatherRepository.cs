using AspireSample.Database;
using AspireSample.Database.Weather;
using Microsoft.EntityFrameworkCore;

namespace AspireSample.ApiService.Weather;

public interface IWeatherRepository
{
   Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync(); 
}

public class WeatherRepository: IWeatherRepository
{
   private readonly WeatherContext _context;
   
   public WeatherRepository(WeatherContext context)
   {
      _context = context;
   }

   public async Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync()
   {
      return await _context.Weather.ToListAsync();
   }
}
