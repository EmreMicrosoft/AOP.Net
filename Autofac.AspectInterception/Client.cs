using Autofac.AspectInterception.Services;


namespace Autofac.AspectInterception;

public class Client
{
    private readonly ITestService _testService;
    public Client(ITestService testService)
    {
        _testService = testService;
    }

    public void Request()
    {
        _testService.TestMethod();
    }
}