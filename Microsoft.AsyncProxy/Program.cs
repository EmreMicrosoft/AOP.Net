using Microsoft.AsyncProxy;
using Microsoft.AsyncProxy.Services;


// *** THIS REPOSITORY IS NOT READY YET ***
// *** THIS REPOSITORY IS NOT READY YET ***
// *** THIS REPOSITORY IS NOT READY YET ***
// *** THIS REPOSITORY IS NOT READY YET ***
// *** THIS REPOSITORY IS NOT READY YET ***

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IWeatherService, WeatherService>();

var syncProxy = SyncProxy<IWeatherService>
    .Create(new WeatherService());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();