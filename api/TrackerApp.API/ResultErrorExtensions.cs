using Microsoft.AspNetCore.Http;
using TrackerApp.Result.Errors;

namespace TrackerApp.API;

// Reconsider using of these extensions
public static class ResultErrorExtensions
{
    public static IResult ToHttpResult(this NotFoundError error)
    {
        return Results.NotFound(error.Message);
    }
}