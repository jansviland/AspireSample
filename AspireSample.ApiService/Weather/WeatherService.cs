using AspireSample.Database.Weather;

namespace AspireSample.ApiService.Weather;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync();
}

public class WeatherService : IWeatherService
{
    private readonly IWeatherRepository _weatherRepository;
    
    public WeatherService(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public async Task<IEnumerable<WeatherForecastDb>> GetWeatherForecastAsync()
    {
        var weatherForecastsDb = await _weatherRepository.GetWeatherForecastAsync();
        return weatherForecastsDb;
    }
}
