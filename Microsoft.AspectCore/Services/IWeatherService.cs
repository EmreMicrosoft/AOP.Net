using Microsoft.AspectCore.Attributes;
using Microsoft.AspectCore.Models;


namespace Microsoft.AspectCore.Services;

public interface IWeatherService
{
    [Logger]
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}