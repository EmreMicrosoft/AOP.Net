using Microsoft.DispatchProxy;
using Microsoft.DispatchProxy.Extensions;
using Microsoft.DispatchProxy.Services;


var builder = WebApplication.CreateBuilder(args);

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