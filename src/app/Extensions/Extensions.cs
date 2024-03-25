using app.Apis;
using lib.Extensions;
namespace app.Extensions;

public static class Extensions
{
    public static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
    {
        builder.AddHttpClient<GoogleApi>(opt =>
        {
            opt.BaseAddress = "https://google.com";
            opt.Timeout = TimeSpan.FromSeconds(15);
        });
        return builder;
    }
}
