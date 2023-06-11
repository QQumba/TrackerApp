using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace TrackerApp.API.Endpoints.Infrastructure;

public static class EndpointDefinitionExtensions
{
    public static IEndpointRouteBuilder MapEndpoints<T>(this IEndpointRouteBuilder routeBuilder, string prefix,
        string swaggerGroup)
        where T : IEndpointsDefinition, new()
    {
        var t = new T();
        var builder = routeBuilder.MapGroup(prefix).WithTags(swaggerGroup);
        t.MapEndpoints(builder);

        return routeBuilder;
    }
}