using DotNetCore.AspectCore.Attributes;
using DotNetCore.AspectCore.Models;


namespace DotNetCore.AspectCore.Services;

public interface IWeatherService
{
    [Logger]
    Task<IEnumerable<WeatherModel>> GetWeatherAsync();
}