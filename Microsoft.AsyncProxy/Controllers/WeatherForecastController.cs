using Microsoft.AspNetCore.Mvc;
using Microsoft.AsyncProxy.Models;
using Microsoft.AsyncProxy.Services;


namespace Microsoft.AsyncProxy.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult<IEnumerable<WeatherModel>>> Get()
    {
        return Ok(await _weatherService.GetWeatherAsync());
    }
}