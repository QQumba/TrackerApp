using Microsoft.AspNetCore.Routing;

namespace TrackerApp.API.Endpoints.Infrastructure;

public interface IEndpointsDefinition
{
    void MapEndpoints(RouteGroupBuilder routeBuilder);
}