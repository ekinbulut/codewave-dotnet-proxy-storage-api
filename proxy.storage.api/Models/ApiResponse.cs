namespace proxy.storage.api.Models;

public class ApiResponse
{
    public object Message { get; set; }
    public string Error { get; set; }
    public int StatusCode { get; set; }
}