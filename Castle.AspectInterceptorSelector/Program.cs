using Castle.AspectInterceptorSelector.Aspects;
using Castle.AspectInterceptorSelector.Proxy;
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