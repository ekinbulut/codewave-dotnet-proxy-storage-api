namespace proxy.storage.api.service;

public class ApiHttpResponse
{
    public object Message { get; set; }
    public string Error { get; set; }
    public int StatusCode { get; set; }
}