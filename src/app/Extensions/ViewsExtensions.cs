using app.Pages;

namespace app.Extensions;

public static class ViewsExtensions
{
    public static MauiAppBuilder RegisterViews(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<GooglePage>();
        return builder;
    }
}
