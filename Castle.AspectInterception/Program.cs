using Castle.AspectInterception;
using Castle.AspectInterception.Aspects;
using Castle.AspectInterception.Services;
using Castle.DynamicProxy;


var client = new Client();
client.Request();

var proxy = new ProxyGenerator();
var aspect = proxy.CreateInterfaceProxyWithoutTarget<IWeatherService>(new InterceptionAspect());
    //new IInterceptor[]
    //{
    //    new InterceptionAspect(),
    //});