using Microsoft.AspNetCore.Routing;

namespace TrackerApp.API.Endpoints.Infrastructure;

public static class EndpointDefinitionExtensions
{
    public static IEndpointRouteBuilder MapEndpoints<T>(this IEndpointRouteBuilder routeBuilder, string prefix,
        string swaggerGroup)
        where T : IEndpointsDefinition, new()
    {
        var t = new T();
        t.MapEndpoints(routeBuilder, prefix, swaggerGroup);

        return routeBuilder;
    }
}