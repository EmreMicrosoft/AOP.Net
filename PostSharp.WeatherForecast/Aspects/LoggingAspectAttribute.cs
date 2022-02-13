using System.Diagnostics;
using PostSharp.Aspects;
using PostSharp.Serialization;


namespace PostSharp.WeatherForecast.Aspects;

[PSerializable]
public class LoggingAspectAttribute : MethodInterceptionAspect
{
    public override async Task OnInvokeAsync(MethodInterceptionArgs args)
    {
        var sw = Stopwatch.StartNew();
        await args.ProceedAsync();
        sw.Stop();

        Console.WriteLine($"{args.Method} executed in {sw.ElapsedMilliseconds} ms.");
    }
}