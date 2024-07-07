using AspireSample.Database.Weather;
using AspireSample.Shared.Models;

namespace AspireSample.ApiService.Weather;

public static class WeatherMapper
{
    public static WeatherForecast Map(this WeatherForecastDb weatherForecastDb)
    {
        return new WeatherForecast(
            new DateOnly(weatherForecastDb.Date.Year, weatherForecastDb.Date.Month, weatherForecastDb.Date.Day),
            weatherForecastDb.TemperatureC,
            weatherForecastDb.Summary);
    }
    
}
