using CommunityToolkit.Mvvm.ComponentModel;

namespace app.ViewModels.Base;

public partial class BaseViewModel : ObservableObject
{
    public virtual Task InitializeAsync(object? data) => Task.CompletedTask;
}
