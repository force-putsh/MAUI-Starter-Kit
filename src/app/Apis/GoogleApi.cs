using System.Net;
using app.Apis.Errors;
using lib.Results;

namespace app.Apis;

public class GoogleApi(IClient client)
{
    private readonly IClient _client = client;
    public async Task<Result<string, Error>> Index()
    {
        try
        {
            return await _client.GetAsync<string,Error>("", (m) => new Error(m));
        }
        catch (TaskCanceledException)
        {
            return ApiErrors.PoorInternetConnection();
        }
        catch (WebException)
        {
            return ApiErrors.NoInternetConnection();
        }
        catch (Exception ex)
        {
            return ApiErrors.UnexpectedError(ex.Message);
        }
    }
}
