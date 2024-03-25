using app.Pages;

namespace app;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		// Register Application routes
		Routing.RegisterRoute(nameof(GooglePage), typeof(GooglePage));
	}
}
