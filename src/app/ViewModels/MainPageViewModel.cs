using app.Apis;
using app.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using lib.Services.Interfaces;

namespace app.ViewModels;

public partial class MainPageViewModel(
    GoogleApi googleApi,
    IDisplayService displayService,
    IPageService pageService) : ObservableObject
{
    private readonly GoogleApi _googleApi = googleApi;
    private readonly IDisplayService _displayService = displayService;
    private readonly IPageService _pageService = pageService;

    [RelayCommand]
    private async Task LoadGoogle()
    {
        var result = await _googleApi.Index();
        if(result.IsSuccess)
            await _pageService.GoToAsync(nameof(GooglePage), new Dictionary<string, object>()
            {
                { nameof(GooglePageViewModel.ContentString), result.Value! }
            });
        else
            await _displayService.DisplayAlert("Error", result.Error!.Message, "OK");
    }
}
