using Microsoft.DispatchProxy.Models;


namespace Microsoft.DispatchProxy.Services;

public interface IWeatherService
{
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}