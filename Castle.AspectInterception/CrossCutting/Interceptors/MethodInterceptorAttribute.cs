using Castle.DynamicProxy;


namespace Castle.AspectInterception.CrossCutting.Interceptors;

[AttributeUsage(AttributeTargets.Class
                | AttributeTargets.Method
                | AttributeTargets.Assembly,
                  AllowMultiple = true, Inherited = true)]
public abstract class MethodInterceptorAttribute
    : Attribute, IAsyncInterceptor
{
    public int Priority { get; set; }

    public virtual void InterceptSynchronous(IInvocation invocation) { }
    public virtual void InterceptAsynchronous(IInvocation invocation) { }
    public virtual void InterceptAsynchronous<TResult>(IInvocation invocation) { }
}