using Microsoft.AspNetCore.Routing;

namespace TrackerApp.API.Endpoints.Infrastructure;

public interface IEndpointsDefinition
{
    void MapEndpoints(IEndpointRouteBuilder routeBuilder, string prefix, string swaggerGroup);
}