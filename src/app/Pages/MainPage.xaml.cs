using app.ViewModels;

namespace app.Pages;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}
