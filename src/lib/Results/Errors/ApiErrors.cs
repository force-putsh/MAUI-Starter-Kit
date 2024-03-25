using lib.Results;

namespace app.Apis.Errors;

public static class ApiErrors
{
    public static Error UnexpectedError(string message) => new (message);
    public static Error Error(string message) => new (message);
    public static Error PoorInternetConnection() => new ("Poor internet connection");
    public static Error NoInternetConnection() => new ("No internet connection");
}
