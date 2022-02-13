using Microsoft.AspNetCore.Mvc;
using Microsoft.WeatherForecast.Aspects;
using Microsoft.WeatherForecast.Services;


namespace Microsoft.WeatherForecast.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [LoggingAspect, HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _weatherService.GetWeatherAsync());
    }
}