using app.Apis;
using lib.Services.Concrete;

namespace lib.Extensions;

public static class HttpClientExtensions
{
    /// <summary>
    /// Registers an <see cref="IClient"/> service with the specified configuration, and the associated T consumer both as singletons.
    /// This <see cref="IClient"/> will only be valid inside this specific consumer class and wont be accessible directly from the DI Container.
    /// </summary>
    /// <typeparam name="T">The consumer of the <see cref="IClient"/> interface we want to register.</typeparam>
    /// <param name="builder"></param>
    /// <param name="configurations">Specifies how to override default parameters.</param>
    /// <returns>The builder instance that was altered based on the configurations made inside the method.</returns>
    public static MauiAppBuilder AddHttpClient<T>(this MauiAppBuilder builder, Action<HttpClientOptions> configurations) 
        where T : class
    {
        var options = new HttpClientOptions();
        configurations(options);
        builder.Services.AddKeyedSingleton(typeof(T), implementationFactory: (_, __) => new HttpClient()
        {
            BaseAddress = new Uri(options.BaseAddress),
            Timeout = options.Timeout
        });
        builder.Services.AddKeyedSingleton<IClient, Client>(serviceKey: typeof(T), (sp, _) => (Client) CreateInstance(typeof(Client), typeof(T), sp));
        builder.Services.AddSingleton(sp => (T) CreateInstance(typeof(T), typeof(T), sp));
        return builder;
    }

    private static object CreateInstance(Type type, Type key, IServiceProvider sp)
    {
        if (!type.IsClass && !type.IsInterface)
        {
            return default!;
        }

        if(type.IsInterface)
        {
            return sp.GetRequiredKeyedService(type, key);
        }

        var ctor = type.GetConstructors()[0];
        var paramTypes = ctor
            .GetParameters()
            .Select(p => p.ParameterType)
            .ToArray();

        var paramInstances = new object[paramTypes.Length];

        for (var i = 0; i < paramTypes.Length; i++)
        {
            if(paramTypes[i] == typeof(HttpClient))
            {
                paramInstances[i] = sp.GetRequiredKeyedService(paramTypes[i], key);
                continue;
            }
            paramInstances[i] = sp.GetService(paramTypes[i]) ?? CreateInstance(paramTypes[i], key, sp);
        }

        if (paramTypes.Length == 0)
            return Activator.CreateInstance(type, true)!;

        return ctor.Invoke(paramInstances);
    }
}
