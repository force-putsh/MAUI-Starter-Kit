namespace lib.Services.Interfaces;

public interface IPageService : INavigation
{
    //
    // Summary:
    //     To be added.
    //
    // Parameters:
    //   state:
    //     To be added.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     To be added.
    public Task GoToAsync(ShellNavigationState state);
    //
    // Summary:
    //     Asynchronously navigates to state, optionally animating.
    //
    // Parameters:
    //   state:
    //     To be added.
    //
    //   animate:
    //     To be added.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     Note that Microsoft.Maui.Controls.ShellNavigationState has implicit conversions
    //     from string and System.Uri, so developers may write code such as the following,
    //     with no explicit instantiation of the Microsoft.Maui.Controls.ShellNavigationState:
    //     await Shell.Current.GoToAsync("app://xamarin.com/xaminals/animals/monkeys");
    public Task GoToAsync(ShellNavigationState state, bool animate);
    //
    // Summary:
    //     To be added.
    //
    // Parameters:
    //   state:
    //     To be added.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     To be added.
    public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters);
    //
    // Summary:
    //     Asynchronously navigates to state, optionally animating.
    //
    // Parameters:
    //   state:
    //     To be added.
    //
    //   animate:
    //     To be added.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     Note that Microsoft.Maui.Controls.ShellNavigationState has implicit conversions
    //     from string and System.Uri, so developers may write code such as the following,
    //     with no explicit instantiation of the Microsoft.Maui.Controls.ShellNavigationState:
    //     await Shell.Current.GoToAsync("app://xamarin.com/xaminals/animals/monkeys");
    public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters);
}
