using app.ViewModels;

namespace app.Pages;

public partial class GooglePage : ContentPage
{
	private readonly GooglePageViewModel _viewModel;
	public GooglePage(GooglePageViewModel vm)
	{
		_viewModel = vm;
		BindingContext = _viewModel;
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
		await _viewModel.InitializeAsync();
    }
}
