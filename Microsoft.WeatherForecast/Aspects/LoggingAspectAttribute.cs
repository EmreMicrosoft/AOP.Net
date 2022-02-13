using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Filters;


namespace Microsoft.WeatherForecast.Aspects;

// Denetleyiciler için.
public class LoggingAspectAttribute : Attribute, IAsyncActionFilter
{
    public async Task OnActionExecutionAsync(
        ActionExecutingContext context,
        ActionExecutionDelegate next)
    {
        var sw = Stopwatch.StartNew();
        
        await next();

        sw.Stop();
        Console.WriteLine($"{context.ActionDescriptor.DisplayName}" +
                          $" executed in {sw.ElapsedMilliseconds} ms.");
    }
}