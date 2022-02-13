namespace Castle.AspectInterception.Proxy;

public class WeatherForecastProxy : IWeatherService
{
    private WeatherService _weatherService;

    public WeatherForecastProxy()
    {
        _weatherService = new WeatherService();
    }


    public IEnumerable<Model> GetWeather()
    {
        Console.WriteLine("Proxy Design Pattern");

        Console.WriteLine("OnBefore");
        try { return _weatherService.GetWeather(); }
        finally { Console.WriteLine("OnBefore"); }
    }
}