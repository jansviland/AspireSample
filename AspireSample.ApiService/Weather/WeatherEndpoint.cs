namespace AspireSample.ApiService.Weather;

public static class WeatherEndpoint
{
    public static async Task<IResult> Get(IWeatherService weatherService)
    {
        var forecast = await weatherService.GetWeatherForecastAsync();
        var response = forecast.Select(f => f.Map());
        
        return Results.Ok(response);
    }
}
