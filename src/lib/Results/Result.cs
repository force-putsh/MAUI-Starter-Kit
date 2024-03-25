namespace lib.Results;

public class Result<TResponse> : Result<TResponse, IError>
{
    public Result(TResponse value) : base(value)
    {
    }

    public Result() : base(new Error())
    {
    }
}

public class Result<TResponse, TError>
{
    public static Result<TResponse, TError> Fail(TError error) => new(error);
    public static Result<TResponse, TError> Ok(TResponse value) => new(value);

    public static implicit operator Result<TResponse, TError>(TResponse value) => Ok(value);

    public static implicit operator Result<TResponse, TError>(TError error) => Fail(error);

    private Result()
    {
        IsSuccess = false;
    }

    protected Result(TResponse value)
    {
        _value = value;
        IsSuccess = true;
    }

    protected Result(TError error)
    {
        _error = error;
        IsSuccess = false;
    }

    private readonly TError? _error;
    private readonly TResponse? _value;
    public bool IsSuccess { get; set; }
    public bool IsFailure => !IsSuccess;
    public TResponse? Value => IsSuccess ? _value : throw new InvalidOperationException("Can't access the Value property since the result is a failure");
    public TError? Error => IsFailure ? _error : throw new InvalidOperationException("Can't access the Error property since the result is a success");
}
