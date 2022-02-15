using Microsoft.DispatchProxy.Models;
using Microsoft.DispatchProxy.Services;


namespace Microsoft.DispatchProxy.Utilities.Decorators;

public class WeatherDecorator : IWeatherService
{
    private readonly IWeatherService _weatherService;
    private readonly ILogger<IWeatherService> _logger;


    public WeatherDecorator(IWeatherService weatherService,
        ILogger<IWeatherService> logger)
    {
        _weatherService = weatherService;
        _logger = logger;
    }

    public async Task<IEnumerable<WeatherModel>> GetWeatherAsync()
    {
        _logger.LogInformation($"*** OnBefore {nameof(GetWeatherAsync)} at WeatherDecorator");
        var result = await _weatherService.GetWeatherAsync();
        _logger.LogInformation($"*** OnAfter {nameof(GetWeatherAsync)} at WeatherDecorator");

        return result;
    }
}