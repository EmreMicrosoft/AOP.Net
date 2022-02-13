namespace Castle.AspectInterception.Proxy;

public interface IWeatherService
{
    IEnumerable<Model> GetWeather();
}