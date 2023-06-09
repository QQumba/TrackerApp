﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Features.Issues.Models;

namespace TrackerApp.API.Features.Issues;

public class IssueEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder, string prefix, string swaggerGroup)
    {
        var builder = routeBuilder.MapGroup(prefix).WithTags(swaggerGroup);
        MapEndpoints(builder);
    }

    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapGet("", GetAllIssues);

        builder.MapPost("", CreateIssue);

        builder.MapGet("{id:long}", GetIssueById);

        builder.MapDelete("{id:long}", DeleteIssue);
    }

    private static async Task<IResult> CreateIssue(IssueCreateDto issueCreateDto, IssuesService service)
    {
        var issue = await service.CreateIssue(issueCreateDto);
        return Results.Created($"{issue.IssueId}", issue);
    }

    private static async Task<IResult> GetAllIssues(IssuesService service)
    {
        var issues = await service.GetAllIssues();
        return Results.Ok(issues);
    }

    private static async Task<IResult> GetIssueById(long id, IssuesService service)
    {
        var result = await service.GetIssueById(id);
        return result.Match(Results.Ok, e => Results.NotFound(e.Message));
    }

    private static async Task<IResult> DeleteIssue(long id, IssuesService service)
    {
        var result = await service.DeleteIssue(id);

        return result.Match(Results.Ok, e => Results.NotFound(e.Message));
    }
}