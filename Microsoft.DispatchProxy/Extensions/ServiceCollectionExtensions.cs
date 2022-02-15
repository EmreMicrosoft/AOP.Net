using System.Reflection;


namespace Microsoft.DispatchProxy.Extensions;

public static class ServiceCollectionExtensions
{
    public static void DecorateWithDispatchProxy<TInterface,
        TProxy>(this IServiceCollection services)
            where TInterface : class
            where TProxy : System.Reflection.DispatchProxy
    {
        MethodInfo createMethod;

        try
        {
            createMethod = typeof(TProxy)
                .GetMethods(BindingFlags.Public
                            | BindingFlags.Static)
                .First(info =>
                    !info.IsGenericMethod
                    && info.ReturnType == typeof(TInterface));
        }
        catch (Exception ex)
        {
            throw new Exception($"Exception : {ex}");
        }

        var argInfos = createMethod.GetParameters();

        var descriptorsToDecorate = services
            .Where(s =>
                s.ServiceType == typeof(TInterface))
            .ToList();

        foreach (var descriptor in descriptorsToDecorate)
        {
            var decorated = ServiceDescriptor.Describe(typeof(TInterface),
                sp =>
                {
                    var decoratorInstance = createMethod.Invoke(null,
                        argInfos.Select(
                                info => info.ParameterType ==
                                        (descriptor.ServiceType)
                                    ? sp.CreateInstance(descriptor)
                                    : sp.GetRequiredService(info.ParameterType))
                            .ToArray());

                    return ((TInterface)decoratorInstance!);
                },
                descriptor.Lifetime);

            services.Remove(descriptor);
            services.Add(decorated);
        }
    }

    private static object CreateInstance(this IServiceProvider services,
        ServiceDescriptor descriptor)
    {
        if (descriptor.ImplementationInstance != null)
            return descriptor.ImplementationInstance;


        return descriptor.ImplementationFactory != null
            ? descriptor.ImplementationFactory(services)
            : ActivatorUtilities.GetServiceOrCreateInstance(services,
                descriptor.ImplementationType!);
    }
}