using System.Reflection;


namespace Microsoft.DispatchProxy;

public class WeatherProxy<TDecorated>
    : System.Reflection.DispatchProxy
{
    private TDecorated _decorated;
    private ILogger<TDecorated> _logger;


    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        _logger.LogInformation($"*** OnBefore target method: {targetMethod.Name}");
        var result = targetMethod.Invoke(_decorated, args);
        _logger.LogInformation($"*** OnAfter target method: {targetMethod.Name}");

        return result;
    }
    
    public static TDecorated Create(TDecorated decorated, ILogger<TDecorated> logger)
    {
        object proxy = Create<TDecorated, WeatherProxy<TDecorated>>();
        ((WeatherProxy<TDecorated>)proxy).SetParameters(decorated, logger);
        return (TDecorated)proxy;
    }

    private void SetParameters(TDecorated decorated,ILogger<TDecorated> logger)
    {
        _decorated = decorated ?? 
            throw new ArgumentNullException(nameof(decorated));

        _logger = logger ??
            throw new ArgumentNullException(nameof(logger));
    }
}