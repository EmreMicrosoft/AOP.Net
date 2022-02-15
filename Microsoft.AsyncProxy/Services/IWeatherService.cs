namespace Microsoft.AsyncProxy.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherForecast>> GetWeatherAsync();
}