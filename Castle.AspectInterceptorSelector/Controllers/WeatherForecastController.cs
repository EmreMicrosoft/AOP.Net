using Castle.AspectInterceptorSelector.Services;
using Microsoft.AspNetCore.Mvc;


namespace Castle.AspectInterceptorSelector.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [HttpGet(Name = "GetWeatherForecast")]
    public ActionResult Get()
    {
        return Ok(_weatherService.GetWeather());
    }
}