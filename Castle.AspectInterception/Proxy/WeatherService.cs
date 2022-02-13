namespace Castle.AspectInterception.Proxy;

public class WeatherService : IWeatherService
{
    public IEnumerable<Model> GetWeather()
    {
        return Enumerable.Range(1, 5).Select(index => new Model
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
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

    public virtual void TestMethod()
    {
        Console.WriteLine("Method runs : Test OK");
    }
}