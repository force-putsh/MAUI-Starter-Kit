using lib.Services.Interfaces;

namespace lib.Services.Concrete;

internal class DisplayService : IDisplayService
{
    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons)
    {
        return Shell.Current.DisplayActionSheet(title, cancel, destruction, buttons);
    }

    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons)
    {
        return Shell.Current.DisplayActionSheet(title, cancel, destruction, flowDirection, buttons);
    }

    public Task DisplayAlert(string title, string message, string cancel)
    {
        return Shell.Current.DisplayAlert(title, message, cancel);
    }

    public Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
    {
        return Shell.Current.DisplayAlert(title, message, accept, cancel);
    }

    public Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection)
    {
        return Shell.Current.DisplayAlert(title, message, accept, cancel, flowDirection);
    }

    public Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection)
    {
        return Shell.Current.DisplayAlert(title, message, cancel, flowDirection);
    }

    public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = "", int maxLength = -1, Keyboard keyboard = null!, string initialValue = "")
    {
        return Shell.Current.DisplayPromptAsync(title, message, accept, cancel, placeholder, maxLength, keyboard, initialValue);
    }
}
