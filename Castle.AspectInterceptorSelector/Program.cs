using Castle.AspectInterceptorSelector.Aspects;
using Castle.AspectInterceptorSelector.Services;
using Castle.DynamicProxy;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();


var proxy = new ProxyGenerator();
var aspect = proxy.CreateClassProxy<WeatherService>(
    new IInterceptor[]
    {
        new InterceptionAspect(),
    });

aspect.TestMethod();



var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
