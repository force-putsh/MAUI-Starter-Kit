using lib.Services.Interfaces;

namespace lib.Services.Concrete;

internal class PageService : IPageService
{
    public IReadOnlyList<Page> ModalStack => Shell.Current.Navigation.ModalStack;
    public IReadOnlyList<Page> NavigationStack => Shell.Current.Navigation.NavigationStack;


    #region Shell behaviour
    public Task GoToAsync(ShellNavigationState state)
    {
        return Shell.Current.GoToAsync(state);
    }

    public Task GoToAsync(ShellNavigationState state, bool animate)
    {
        return Shell.Current.GoToAsync(state, animate);
    }

    public Task GoToAsync(ShellNavigationState state, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, parameters);
    }

    public Task GoToAsync(ShellNavigationState state, bool animate, IDictionary<string, object> parameters)
    {
        return Shell.Current.GoToAsync(state, animate, parameters);
    }
    #endregion

    public void InsertPageBefore(Page page, Page before)
    {
        Shell.Current.Navigation.InsertPageBefore(page, before);
    }

    public Task<Page> PopAsync()
    {
        return Shell.Current.Navigation.PopAsync();
    }

    public Task<Page> PopAsync(bool animated)
    {
        return Shell.Current.Navigation.PopAsync(animated);
    }

    public Task<Page> PopModalAsync()
    {
        return Shell.Current.Navigation.PopModalAsync();
    }

    public Task<Page> PopModalAsync(bool animated)
    {
        return Shell.Current.Navigation.PopModalAsync(animated);
    }

    public Task PopToRootAsync()
    {
        return Shell.Current.Navigation.PopToRootAsync();
    }

    public Task PopToRootAsync(bool animated)
    {
        return Shell.Current.Navigation.PopToRootAsync(animated);
    }

    public Task PushAsync(Page page)
    {
        return Shell.Current.Navigation.PushAsync(page);
    }

    public Task PushAsync(Page page, bool animated)
    {
        return Shell.Current.Navigation.PushAsync(page, animated);
    }

    public Task PushModalAsync(Page page)
    {
        return Shell.Current.Navigation.PushModalAsync(page);
    }

    public Task PushModalAsync(Page page, bool animated)
    {
        return Shell.Current.Navigation.PushModalAsync(page, animated);
    }

    public void RemovePage(Page page)
    {
        Shell.Current.Navigation.RemovePage(page);
    }
}
