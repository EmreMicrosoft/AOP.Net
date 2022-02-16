using Microsoft.AspNetCore.Mvc;


namespace DotNetCore.AspectCore.Controllers;

[ApiController, Route("api/[controller]")]
public abstract class ApiController : ControllerBase { }