using Castle.AspectInterception.Aspects;
using Castle.AspectInterception.Services;


namespace Castle.AspectInterception;

public class Client
{
    private readonly IWeatherService _weatherService;
    public Client()
    {
        // TODO : Refactor DI.
        _weatherService = new WeatherService();
    }


    [InterceptionAspect]
    public IEnumerable<Model> Request()
    {
        return _weatherService.GetWeather();
    }
}