using Microsoft.WeatherForecast.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DI with Decorator Design Pattern
builder.Services.AddSingleton<WeatherService>();
builder.Services.AddSingleton<IWeatherService>(serviceProvider
    => new WeatherDecoratorService(serviceProvider
        .GetRequiredService<WeatherService>()));

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
