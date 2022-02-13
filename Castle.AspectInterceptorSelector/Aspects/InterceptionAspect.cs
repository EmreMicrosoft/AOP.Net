using Castle.DynamicProxy;


namespace Castle.AspectInterceptorSelector.Aspects;

public class InterceptionAspect : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine($"TargetType {invocation.TargetType}");
        Console.WriteLine($"OnBefore {invocation.Method.Name}");

        invocation.Proceed();

        Console.WriteLine($"OnAfter {invocation.Method.Name}");
    }
}