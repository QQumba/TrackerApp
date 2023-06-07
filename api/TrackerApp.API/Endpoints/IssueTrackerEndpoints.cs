using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Models;

namespace TrackerApp.API.Endpoints;

public class IssueTrackerEndpoints : IEndpointsDefinition
{
    private static readonly List<Issue> Issues = new()
    {
        new Issue(0, "test", "nick"),
        new Issue(1, "help", "kick")
    };

    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapGet("", GetAllIssues);

        builder.MapPost("", CreateNewIssue);
    }

    private static IResult GetAllIssues()
    {
        return Results.Ok(Issues);
    }

    private static IResult CreateNewIssue(Issue issue)
    {
        var id = Issues.Select(x => x.Id).Max();
        issue.Id = id + 1;
        Issues.Add(issue);

        return Results.Created($"{issue.Id}", issue);
    }
}