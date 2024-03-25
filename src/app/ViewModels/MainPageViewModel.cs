using app.Apis;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace app.ViewModels;

public partial class MainPageViewModel(GoogleApi googleApi) : ObservableObject
{
    private readonly GoogleApi _googleApi = googleApi;

    [RelayCommand]
    private async Task LoadGoogle()
    {
        var result = await _googleApi.Index();
    }
}
