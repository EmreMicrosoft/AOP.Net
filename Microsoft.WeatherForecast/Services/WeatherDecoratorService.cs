using System.Diagnostics;


namespace Microsoft.WeatherForecast.Services;

// Servisler için (Decorator Design Pattern)
public class WeatherDecoratorService : IWeatherService
{
    private readonly IWeatherService _weatherService;

    public WeatherDecoratorService(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
    {
        var sw = Stopwatch.StartNew();

        try { return await _weatherService.GetWeatherAsync(); }
        finally
        {
            sw.Stop();
            Console.WriteLine($"{nameof(GetWeatherAsync)}" +
                              $" executed in {sw.ElapsedMilliseconds} ms.");
        }
    }
}