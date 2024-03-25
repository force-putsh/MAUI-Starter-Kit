using app.ViewModels;

namespace app;

public partial class MainPage : ContentPage
{
	public MainPage(MainPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}
