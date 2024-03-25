namespace lib.Extensions;

public class HttpClientOptions
{
    public string BaseAddress { get; set; } = string.Empty;
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}
