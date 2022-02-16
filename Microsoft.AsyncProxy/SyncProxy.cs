using System.Reflection;

namespace Microsoft.AsyncProxy;

public class SyncProxy<T> : DispatchProxy
{
    private T _decorated;

    private Action<MethodInfo, object[]> _onBefore;
    private Action<MethodInfo, object[], Exception> _onException;
    private Action<MethodInfo, object[], object> _onAfter;

    
    public static T Create(T decorated,
        Action<MethodInfo, object[]> onBefore = null,
        Action<MethodInfo, object[], Exception> onException = null,
        Action<MethodInfo, object[], object> onAfter = null)
    {
        object proxy = Create<T, SyncProxy<T>>();
        SetParameters();
        return (T)proxy;

        void SetParameters()
        {
            var proxyT = ((SyncProxy<T>)proxy);

            proxyT._decorated = decorated == null ?
                throw new ArgumentNullException(nameof(decorated)) : decorated;

            proxyT._onBefore = onBefore;
            proxyT._onException = onException;
            proxyT._onAfter = onAfter;
        }
    }


    protected override object Invoke(MethodInfo targetMethod, object[] args)
    {
        _ = targetMethod ??
            throw new ArgumentException(nameof(targetMethod));

        try
        {
            Console.WriteLine("Proxy triggered. Test OK!");
            _onBefore?
                .Invoke(targetMethod, args);

            var result = targetMethod
                .Invoke(_decorated, args);

            _onAfter?
                .Invoke(targetMethod, args, result);

            return result;
        }
        catch (Exception ex)
        {
            _onException?
                .Invoke(targetMethod, args, ex);

            throw ex.InnerException!;
        }
    }
}