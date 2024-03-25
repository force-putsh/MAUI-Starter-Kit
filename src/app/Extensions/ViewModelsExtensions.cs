using app.ViewModels;
namespace app.Extensions;

public static class ViewModelsExtensions
{
    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<GooglePageViewModel>();
        return builder;
    }
}
