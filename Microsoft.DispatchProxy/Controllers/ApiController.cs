using Microsoft.AspNetCore.Mvc;


namespace Microsoft.DispatchProxy.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController : ControllerBase { }