using Castle.AspectInterception.CrossCutting.Interceptors;
using Castle.DynamicProxy;


namespace Castle.AspectInterception.Aspects;

public class InterceptionAspect : MethodInterceptor
{
    public override void OnBefore(IInvocation invocation)
    {
        Console.WriteLine($"OnBefore   : {invocation.Method}");
        Console.WriteLine($"Proxy      : {invocation.Proxy}");
        Console.WriteLine($"TargetType : {invocation.TargetType}");

        if (!invocation.Arguments.Any())
            return;

        Console.WriteLine();
        Console.WriteLine("ARGUMENTS  -->");
        foreach (var arg in invocation.Arguments)
        {
            Console.WriteLine($"  Type : {arg.GetType()} | {arg}");
        }
    }


    public override void OnAfter(IInvocation invocation)
    {
        Console.WriteLine($"OnAfter    : {invocation.Method.Name}");
        Console.WriteLine();
    }
}