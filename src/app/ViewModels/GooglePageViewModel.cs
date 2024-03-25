using app.ViewModels.Base;
using CommunityToolkit.Mvvm.ComponentModel;

namespace app.ViewModels;

[QueryProperty(nameof(ContentString), nameof(ContentString))]
public partial class GooglePageViewModel : BaseViewModel
{
    [ObservableProperty]
    private string _contentString = string.Empty;

    [ObservableProperty]
    private HtmlWebViewSource _content = new();

    public override Task InitializeAsync(object? data = null)
    {
        Content.Html = ContentString;
        return base.InitializeAsync(data);
    }
}
