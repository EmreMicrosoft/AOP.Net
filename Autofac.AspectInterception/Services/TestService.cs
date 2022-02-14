using Autofac.AspectInterception.Aspects;


namespace Autofac.AspectInterception.Services;

public class TestService : ITestService
{
    // Priority:Aspect'lerin önceliğini belirtir;
    //   tek aspect kullanılıyorsa set edilmesi gerekmez.
    [InterceptionAspect(Priority = 1)]
    public virtual void TestMethod()
    {
        Console.WriteLine("Method Result : Test OK");
    }
}