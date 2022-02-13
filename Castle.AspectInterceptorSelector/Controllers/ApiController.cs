using Microsoft.AspNetCore.Mvc;


namespace Castle.AspectInterceptorSelector.Controllers;

[ApiController, Route("[controller]/api")]
public abstract class ApiController : ControllerBase { }