using System.Reflection;
using Microsoft.Extensions.Caching.Distributed;


namespace Microsoft.DispatchProxy.Utilities.Attributes;

public interface ICacheAttribute
{
    string OnBefore(MethodInfo targetMethod,
        object[] args, IDistributedCache distributedCache);
    void OnAfter(MethodInfo targetMethod,
        object[] args, object value,
        IDistributedCache distributedCache);
}