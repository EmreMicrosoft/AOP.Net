﻿using Microsoft.AspNetCore.Mvc;


namespace Microsoft.AsyncProxy.Controllers;

[ApiController, Route("api/[controller]")]
public abstract class ApiController : ControllerBase { }