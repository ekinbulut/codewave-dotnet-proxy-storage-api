using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using proxy.storage.api.service;

namespace proxy.storage.api.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;
    
    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logger)
    {
        _logger = logger.CreateLogger<ExceptionMiddleware>();
        _next = next;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Something went wrong: {ex}");
            await HandleExceptionAsync(httpContext, ex);
        }
    }
    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ApiHttpResponse()
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error from the middleware."
        }.ToString() ?? string.Empty);
    }
}