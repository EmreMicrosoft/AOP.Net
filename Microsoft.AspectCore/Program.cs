using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Extensions.Hosting;

using Microsoft.AspectCore.Attributes;
using Microsoft.AspectCore.Services;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



// *** Begin
builder.Host.UseDynamicProxy();
builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

builder.Services.ConfigureDynamicProxy(options =>
{
    options.Interceptors.AddTyped<LoggerAttribute>();
});

builder.Services.AddSingleton<IWeatherService, WeatherService>();
// *** End




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