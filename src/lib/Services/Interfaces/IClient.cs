using lib.Results;

namespace app.Apis;

/// <summary>
/// Provides basic Http functionalities.
/// </summary>
public interface IClient
{
    Task<Result<TResponse, TError>> PostAsync<TRequest, TResponse, TError>(string route,
        TRequest request,
        Func<string, TError> onError)
        where TError : class, IError;

    Task<Result<TResponse, TError>> PutAsync<TRequest, TResponse, TError>(string route, TRequest request, Func<string, TError> onError)
        where TError : class, IError;

    Task<Result<TResponse, TError>> GetAsync<TResponse, TError>(string route, Func<string, TError>? onError)
        where TError : class, IError;

    Task<Result<TResponse, TError>> DeleteAsync<TResponse, TError>(string route, Func<string, TError> onError)
        where TError : class, IError;
}
