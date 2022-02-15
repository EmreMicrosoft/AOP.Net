namespace Microsoft.AsyncProxy.Services;

public class WeatherService : IWeatherService
{
    public async Task<IEnumerable<WeatherForecast>> GetWeatherAsync()
    {
        var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        await Task.Delay(Random.Shared.Next(40, 400));
        return weather;
    }


    private static readonly string[] Summaries =
    {
        "Freezing",
        "Bracing",
        "Chilly",
        "Cool",
        "Mild",
        "Warm",
        "Balmy",
        "Hot",
        "Sweltering",
        "Scorching"
    };
}