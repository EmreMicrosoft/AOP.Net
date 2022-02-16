using Microsoft.AsyncProxy.Models;


namespace Microsoft.AsyncProxy.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}