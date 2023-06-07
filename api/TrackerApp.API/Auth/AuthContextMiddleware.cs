using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using TrackerApp.Data;

namespace TrackerApp.API.Auth;

public class AuthContextMiddleware
{
    private readonly RequestDelegate _next;

    public AuthContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, AuthContext authContext)
    {
        if (context.User.Identity is { IsAuthenticated: true })
        {
            authContext.Populate(context.User);
        }

        await _next.Invoke(context);
    }
}

public static class AuthContextMiddlewareExtensions
{
    public static IApplicationBuilder UseAuthContextPopulation(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<AuthContextMiddleware>();
    }
}