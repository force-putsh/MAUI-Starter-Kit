namespace lib.Results;

public sealed class Error : IError
{
    public string Detail { get; set; } = "An unexpected error occurred";
    public Error()
    {
    }
    public Error(string message)
    {
        Detail = message;
    }
}
