using app.Apis;
using lib.Services.Concrete;

namespace lib.Extensions;

public static class HttpClientExtensions
{
    public static MauiAppBuilder AddHttpClient<T>(this MauiAppBuilder builder) 
        where T : class, new()
    {
        builder.Services.AddKeyedSingleton<HttpClient>(typeof(T));
        builder.Services.AddKeyedSingleton<IClient, Client>(typeof(T));
        builder.Services.AddSingleton(sp => (T) CreateInstance(typeof(T), typeof(T), sp));
        return builder;
    }

    private static object CreateInstance(Type type, Type key, IServiceProvider sp)
    {
        if (!type.IsClass)
        {
            return default!;
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
                paramInstances[i] = sp.GetKeyedServices(paramTypes[i], key) ?? CreateInstance(paramTypes[i], key, sp);
                continue;
            }
            paramInstances[i] = sp.GetService(paramTypes[i]) ?? CreateInstance(paramTypes[i], key, sp);
        }

        if (paramTypes.Length == 0)
            return Activator.CreateInstance(type)!;

        return Activator.CreateInstance(type, paramTypes)!;
    }
}
