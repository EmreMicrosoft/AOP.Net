using Microsoft.AspNetCore.Mvc;
using Microsoft.DispatchProxy.Services;


namespace Microsoft.DispatchProxy.Controllers;

public class WeatherForecastController : ApiController
{
    private readonly IWeatherService _weatherService;
    public WeatherForecastController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<ActionResult> Get()
    {
        return Ok(await _weatherService.GetWeatherAsync());
    }
}