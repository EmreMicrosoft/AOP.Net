using AspectCore.DynamicProxy;


namespace Microsoft.AspectCore.Attributes;

public class LoggerAttribute : AbstractInterceptorAttribute
{
    public override async Task Invoke(AspectContext context,
                                      AspectDelegate next)
    {
        try
        {
            Console.WriteLine("OnBefore Invoking");
            await next(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine("OnException");
            Console.WriteLine($"Error: {ex}");
            throw;
        }
        finally
        {
            Console.WriteLine("OnAfter Invoking");
        }
    }
}