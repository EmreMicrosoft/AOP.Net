namespace Castle.AspectInterceptorSelector.Proxy;

public interface IWeatherService
{
    IEnumerable<Model> GetWeather();
}