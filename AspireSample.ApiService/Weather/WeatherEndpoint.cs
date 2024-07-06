namespace AspireSample.ApiService.Weather;

public static class WeatherEndpoint
{
    public static async Task<IResult> Get(IWeatherService weatherService)
    {
        var forecast = await weatherService.GetWeatherForecastAsync();
        
        // TODO: map to response
        
        return Results.Ok(forecast);
    }
}
