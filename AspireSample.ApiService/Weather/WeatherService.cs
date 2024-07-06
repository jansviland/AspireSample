namespace AspireSample.ApiService.Weather;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync();
}

public class WeatherService(IWeatherRepository weatherRepository) : IWeatherService
{
    private readonly IWeatherRepository _weatherRepository = weatherRepository;

    public async Task<IEnumerable<WeatherForecast>> GetWeatherForecastAsync()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        
        var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
            .ToArray();
        
        return forecast;
    }
}
