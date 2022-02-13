using Castle.AspectInterception.Aspects;
using Castle.AspectInterception.Proxy;
using Castle.DynamicProxy;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IWeatherService, WeatherService>();


var proxy = new ProxyGenerator();
var aspect = proxy.CreateClassProxy<WeatherService>(
    new IInterceptor[]
    {
        new InterceptionAspect(),
    });

aspect.TestMethod();

var app = builder.Build();
app.Run();