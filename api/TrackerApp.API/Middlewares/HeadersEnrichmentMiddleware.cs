using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace TrackerApp.API.Middlewares;

// It looks like it isn't needed
public class HeadersEnrichmentMiddleware
{
    private readonly RequestDelegate _next;

    public HeadersEnrichmentMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public Task Invoke(HttpContext context)
    {
        // wtf is that
        context.Response.ContentLength = 135;
        return _next(context);
    }
}

public static class HeadersPopulationMiddlewareExtensions
{
    public static IApplicationBuilder UseHeadersEnrichment(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<HeadersEnrichmentMiddleware>();
    }
}