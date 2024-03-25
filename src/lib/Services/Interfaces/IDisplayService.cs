namespace lib.Services.Interfaces;

public interface IDisplayService
{
    //
    // Summary:
    //     Displays a native platform action sheet, allowing the application user to choose
    //     from several buttons.
    //
    // Parameters:
    //   title:
    //     Title of the displayed action sheet. Must not be null.
    //
    //   cancel:
    //     Text to be displayed in the 'Cancel' button. Can be null to hide the cancel action.
    //
    //   destruction:
    //     Text to be displayed in the 'Destruct' button. Can be null to hide the destructive
    //     option.
    //
    //   buttons:
    //     Text labels for additional buttons. Must not be null.
    //
    // Returns:
    //     An awaitable Task that displays an action sheet and returns the Text of the button
    //     pressed by the user.
    //
    // Remarks:
    //     Developers should be aware that Windows' line endings, CR-LF, only work on Windows
    //     systems, and are incompatible with iOS and Android. A particular consequence
    //     of this is that characters that appear after a CR-LF, (For example, in the title.)
    //     may not be displayed on non-Windows platforms. Developers must use the correct
    //     line endings for each of the targeted systems.
    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, params string[] buttons);
    public Task<string> DisplayActionSheet(string title, string cancel, string destruction, FlowDirection flowDirection, params string[] buttons);
    //
    // Summary:
    //     Presents an alert dialog to the application user with a single cancel button.
    //
    // Parameters:
    //   title:
    //     The title of the alert dialog.
    //
    //   message:
    //     The body text of the alert dialog.
    //
    //   cancel:
    //     Text to be displayed on the 'Cancel' button.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     To be added.
    public Task DisplayAlert(string title, string message, string cancel);
    //
    // Summary:
    //     Presents an alert dialog to the application user with an accept and a cancel
    //     button.
    //
    // Parameters:
    //   title:
    //     The title of the alert dialog.
    //
    //   message:
    //     The body text of the alert dialog.
    //
    //   accept:
    //     Text to be displayed on the 'Accept' button.
    //
    //   cancel:
    //     Text to be displayed on the 'Cancel' button.
    //
    // Returns:
    //     A task that contains the user's choice as a Boolean value. true indicates that
    //     the user accepted the alert. false indicates that the user cancelled the alert.
    //
    // Remarks:
    //     To be added.
    public Task<bool> DisplayAlert(string title, string message, string accept, string cancel);
    //
    // Summary:
    //     Presents an alert dialog to the application user with an accept and a cancel
    //     button.
    //
    // Parameters:
    //   title:
    //     The title of the alert dialog.
    //
    //   message:
    //     The body text of the alert dialog.
    //
    //   accept:
    //     Text to be displayed on the 'Accept' button.
    //
    //   cancel:
    //     Text to be displayed on the 'Cancel' button.
    //
    // Returns:
    //     A task that contains the user's choice as a Boolean value. true indicates that
    //     the user accepted the alert. false indicates that the user cancelled the alert.
    //
    // Remarks:
    //     To be added.
    public Task<bool> DisplayAlert(string title, string message, string accept, string cancel, FlowDirection flowDirection);
    //
    // Summary:
    //     Presents an alert dialog to the application user with a single cancel button.
    //
    // Parameters:
    //   title:
    //     The title of the alert dialog.
    //
    //   message:
    //     The body text of the alert dialog.
    //
    //   cancel:
    //     Text to be displayed on the 'Cancel' button.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     To be added.
    public Task DisplayAlert(string title, string message, string cancel, FlowDirection flowDirection);
    //
    // Summary:
    //     To be added.
    //
    // Parameters:
    //   title:
    //     To be added.
    //
    //   message:
    //     To be added.
    //
    //   accept:
    //     To be added.
    //
    //   cancel:
    //     To be added.
    //
    //   placeholder:
    //     To be added.
    //
    //   maxLength:
    //     To be added.
    //
    //   keyboard:
    //     To be added.
    //
    //   initialValue:
    //     To be added.
    //
    // Returns:
    //     To be added.
    //
    // Remarks:
    //     To be added.
    public Task<string> DisplayPromptAsync(string title, string message, string accept = "OK", string cancel = "Cancel", string placeholder = "", int maxLength = -1, Keyboard keyboard = null!, string initialValue = "");
}
