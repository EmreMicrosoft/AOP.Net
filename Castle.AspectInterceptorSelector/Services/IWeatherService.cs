namespace Castle.AspectInterceptorSelector.Services;

public interface IWeatherService
{
    IEnumerable<WeatherForecast> GetWeather();
}