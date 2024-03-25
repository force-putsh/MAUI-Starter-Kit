namespace lib.Results;

public sealed class Error : IError
{
    public string Message { get; set; } = "An unexpected error occurred";
    public Error()
    {
    }
    public Error(string message)
    {
        Message = message;
    }
}
