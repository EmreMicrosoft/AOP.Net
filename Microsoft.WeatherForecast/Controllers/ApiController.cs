using Microsoft.AspNetCore.Mvc;


namespace Microsoft.WeatherForecast.Controllers;

[ApiController, Route("[controller]/api")]
public abstract class ApiController : ControllerBase { }