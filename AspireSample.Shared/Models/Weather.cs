namespace AspireSample.Shared.Models;

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF
    {
        get => 32 + (int)(TemperatureC / 0.5556);
    }
}
