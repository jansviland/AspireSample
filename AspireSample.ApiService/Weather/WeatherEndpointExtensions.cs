namespace AspireSample.ApiService.Weather;

public static class WeatherEndpointExtensions
{
    public static WebApplication MapWeatherEndpoint(this WebApplication app)
    {
        app.MapGet("/weatherforecast", WeatherEndpoint.Get)
            .AllowAnonymous();

        return app;
    }
}

