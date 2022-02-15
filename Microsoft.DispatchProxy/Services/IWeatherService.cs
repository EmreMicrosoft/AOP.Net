using Microsoft.DispatchProxy.Models;
using Microsoft.DispatchProxy.Utilities.Attributes;


namespace Microsoft.DispatchProxy.Services;

public interface IWeatherService
{
    [Cache(Key = "Key", Value = 3600)]
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}