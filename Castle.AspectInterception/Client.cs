using Castle.AspectInterception.Proxy;


namespace Castle.AspectInterception;

public class Client
{
    private readonly IWeatherService _weatherService;
    public Client(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    public IEnumerable<Model> Request()
    {
        return _weatherService.GetWeather();
    }
}