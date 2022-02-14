namespace Castle.AspectInterception.Services;

public interface IWeatherService
{
    IEnumerable<Model> GetWeather();
}