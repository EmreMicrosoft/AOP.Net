using Castle.AspectInterceptorSelector.Proxy;


namespace Castle.AspectInterceptorSelector;

public class Request
{
    private readonly IWeatherService _weatherService;
    public Request(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    public IEnumerable<Model> Get()
    {
        return _weatherService.GetWeather();
    }
}