using Microsoft.DispatchProxy.Proxies;
using Microsoft.DispatchProxy.Services;
using Microsoft.DispatchProxy.Utilities.Extensions;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();

builder.Services
    .AddLogging(configure =>
    {
        configure.AddConsole();
        configure.SetMinimumLevel(LogLevel.Information);
    });


builder.Services.DecorateWithDispatchProxy<IWeatherService,
    WeatherProxy<IWeatherService>>();

//builder.Services.DecorateWithDispatchProxy<IWeatherService,
//    CacheProxy<IWeatherService>>();



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
