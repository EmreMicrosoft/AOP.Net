using Autofac;
using Autofac.Extras.DynamicProxy;
using Autofac.AspectInterception.Aspects;
using Autofac.AspectInterception.CrossCutting.Interceptors;
using Autofac.AspectInterception.Services;
using Castle.DynamicProxy;


var builder = new ContainerBuilder();
builder.RegisterType<TestService>()
    .As<ITestService>()
    .EnableInterfaceInterceptors(new ProxyGenerationOptions
    {
        Selector = new InterceptorSelector()
    })
    .InstancePerDependency();

var container = builder.Build();
var service = container.Resolve<ITestService>();

service.TestMethod();


//// Castle.DynamicProxy:
//var proxy = new ProxyGenerator();
//var aspect = proxy.CreateClassProxy<TestService>(
//    new IInterceptor[]
//    {
//        new InterceptionAspect(),
//    });
//
//aspect.TestMethod();