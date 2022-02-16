// Demo: https://520liyan.xyz/cdcd72/NetCore.AspectCore.AOP.Demo

using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;

using DotNetCore.AspectCore.Attributes;
using DotNetCore.AspectCore.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IWeatherService, WeatherService>();


// *** Begin
builder.Host.UseServiceProviderFactory(new DynamicProxyServiceProviderFactory());

builder.Services.ConfigureDynamicProxy(options =>
{
    options.Interceptors.AddTyped<LoggerAttribute>(Predicates.ForMethod("Execute*"));
});
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