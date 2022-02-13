namespace Microsoft.WeatherForecast.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
}