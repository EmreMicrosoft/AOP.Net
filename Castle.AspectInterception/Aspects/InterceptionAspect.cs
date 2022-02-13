using Castle.DynamicProxy;


namespace Castle.AspectInterception.Aspects;

public class InterceptionAspect : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        Console.WriteLine($"Proxy      : {invocation.Proxy}");
        Console.WriteLine($"TargetType : {invocation.TargetType}");

        if (invocation.Arguments.Any())
        {
            Console.WriteLine();
            Console.WriteLine("ARGUMENTS  -->");
            foreach (var arg in invocation.Arguments)
            {
                Console.WriteLine($"  Type : {arg.GetType()} | {arg}");
            }
        }

        Console.WriteLine();
        Console.WriteLine($"OnBefore   : {invocation.Method}");

        invocation.Proceed();

        Console.WriteLine($"OnAfter    : {invocation.Method.Name}");
    }
}