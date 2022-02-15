using System.Reflection;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;


namespace Microsoft.DispatchProxy.Utilities.Attributes;

public class CacheAttribute : Attribute
{
    public string Key { get; set; }
    public int Value { get; set; }


    public string OnBefore(MethodInfo targetMethod,
        object[] args, IDistributedCache distributedCache)
    {
        return distributedCache
            .GetString(Key);
    }

    public void OnAfter(MethodInfo targetMethod,
        object[] args, object value, IDistributedCache distributedCache)
    {
        distributedCache.SetString(Key,
            JsonConvert.SerializeObject(value));
    }
}