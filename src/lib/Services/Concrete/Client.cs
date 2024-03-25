using app.Apis;
using lib.Results;
using lib.Utilities;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace lib.Services.Concrete;

public partial class Client(HttpClient client) : IClient
{
    private readonly HttpClient _client = client;
    private static readonly JsonSerializerOptions _serializeOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    private static readonly JsonSerializerOptions _deserializeOptions = new()
    {
        PropertyNameCaseInsensitive = true,
    };

    public void SetToken(string token)
    {
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }

    public void ClearToken()
    {
        _client.DefaultRequestHeaders.Remove("Authorization");
    }

    public async Task<Result<TResponse, TError>> PostAsync<TRequest, TResponse, TError>(string route, TRequest request, Func<string, TError> onError)
        where TError : class, IError
    {
        return await SendRequestAsync<TRequest, TResponse, TError>(route, request, HttpMethods.Post, onError);
    }

    public async Task<Result<TResponse, TError>> PutAsync<TRequest, TResponse, TError>(string route, TRequest request, Func<string, TError> onError)
        where TError : class, IError
    {
        return await SendRequestAsync<TRequest, TResponse, TError>(route, request, HttpMethods.Put, onError);
    }

    public async Task<Result<TResponse, TError>> DeleteAsync<TResponse, TError>(string route, Func<string, TError> onError)
        where TError : class, IError
    {
        return await SendRequestAsync<object, TResponse, TError>(route, null, HttpMethods.Delete, onError);
    }

    public async Task<Result<TResponse, TError>> GetAsync<TResponse, TError>(string route, Func<string, TError>? onError)
        where TError : class, IError
    {
        return await SendRequestAsync<object, TResponse, TError>(route, null, HttpMethods.Get, onError);
    }

    private async Task<Result<TResponse, TError>> SendRequestAsync<TRequest, TResponse, TError>(string route, TRequest? request, HttpMethods method, Func<string, TError>? onError)
        where TError : class, IError
    {
        var body = new StringContent(JsonSerializer.Serialize(request, _serializeOptions), Encoding.UTF8, "application/json");
        if (method is not HttpMethods.Get and not HttpMethods.Delete)
        {
            ArgumentNullException.ThrowIfNull(request);
        }

        var response = method switch
        {
            HttpMethods.Get => await _client.GetAsync(route),
            HttpMethods.Put => await _client.PutAsync(route, body),
            HttpMethods.Delete => await _client.DeleteAsync(route),
            HttpMethods.Post => await _client.PostAsync(route, body),
            HttpMethods.Patch => await _client.PatchAsync(route, body),
            _ => await _client.PostAsync(route, body)
        };

        string content = await response.Content.ReadAsStringAsync();
        if (response.IsSuccessStatusCode)
        {
            if(typeof(TResponse) == typeof(string))
                return (TResponse)(object) content;
            return JsonSerializer.Deserialize<TResponse>(content, _deserializeOptions)!;
        }
        else
        {
            var error = JsonSerializer.Deserialize<Error>(content, _deserializeOptions)!;
            return onError is not null ? onError.Invoke(error.Message) : DefaultCallback<TError>(error.Message);
        }

        static TTError DefaultCallback<TTError>(string s)
            where TTError : class, IError => default!;
    }
}
