using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace TrackerApp.API;

public static class RouteHandlerBuilderExtensions
{
    public static RouteHandlerBuilder WithOpenApi(this RouteHandlerBuilder builder, string summary, string description)
    {
        return builder.WithOpenApi(op =>
        {
            op.Summary = summary;
            op.Description = description;
            return op;
        });
    }

    public static RouteHandlerBuilder WithParameter(this RouteHandlerBuilder builder, string parameterName,
        string description)
    {
        return builder.WithOpenApi(op =>
        {
            var param = op.Parameters.Single(x => x.Name == parameterName);
            param.Description = description;
            return op;
        });
    }

    public static RouteHandlerBuilder WithParameter(this RouteHandlerBuilder builder, int parameterOrder,
        string description)
    {
        return builder.WithOpenApi(op =>
        {
            var param = op.Parameters[parameterOrder];
            param.Description = description;
            return op;
        });
    }
}