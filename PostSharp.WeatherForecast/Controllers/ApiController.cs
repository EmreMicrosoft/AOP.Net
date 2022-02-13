using Microsoft.AspNetCore.Mvc;


namespace PostSharp.WeatherForecast.Controllers;

[ApiController, Route("[controller]/api")]
public abstract class ApiController : ControllerBase { }