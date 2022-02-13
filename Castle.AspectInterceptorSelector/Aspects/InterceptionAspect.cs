using Castle.DynamicProxy;


namespace Castle.AspectInterceptorSelector.Aspects;

public class InterceptionAspect : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine("OnBefore (InterceptionAspect.cs)");

        invocation.Proceed();

        Console.WriteLine("OnAfter (InterceptionAspect.cs)");
    }
}