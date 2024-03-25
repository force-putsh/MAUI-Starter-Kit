using lib.Services.Concrete;
using lib.Services.Interfaces;

namespace lib.Extensions;

public static class Extensions
{
    public static MauiAppBuilder RegisterLibrary(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<IPageService, PageService>();
        builder.Services.AddSingleton<IDisplayService, DisplayService>();
        return builder;
    }
}
