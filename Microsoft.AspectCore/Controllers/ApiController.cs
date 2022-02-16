using Microsoft.AspNetCore.Mvc;


namespace Microsoft.AspectCore.Controllers;

[ApiController, Route("api/[controller]")]
public abstract class ApiController : ControllerBase { }