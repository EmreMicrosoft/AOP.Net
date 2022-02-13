using Castle.DynamicProxy;


namespace Castle.AspectInterceptorSelector.Aspects;

[AttributeUsage(AttributeTargets.Class |
                AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
{
    public virtual void Intercept(IInvocation invocation)
    {

    }
}