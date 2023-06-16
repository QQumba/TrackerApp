using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Features.Issues.Models;
using TrackerApp.Data;
using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Issues;

public class IssueEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapGet("", GetAllIssues);

        builder.MapPost("", CreateIssue);

        builder.MapGet("{id:long}", GetIssueById);

        builder.MapDelete("{id:long}", DeleteIssue);

        builder.MapPost("{id:long}/tag", AddTag);
    }

    private static async Task<IResult> CreateIssue(IssueCreateDto issueCreateDto,
        IssuesService service,
        IValidator<IssueCreateDto> validator)
    {
        var validationResult = validator.Validate(issueCreateDto);
        if (!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }

        var result = await service.CreateIssue(issueCreateDto);
        return result.Match(issue => Results.Created($"{issue.Id}", issue), e => Results.NotFound(e.Message));
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

        return result.Match(_ => Results.NoContent(), e => Results.NotFound(e.Message));
    }

    private async Task<IResult> AddTag(long id, List<long> tagIds, TrackerAppDbContext context)
    {
        var issueExists = await context.Issue.AnyAsync(x => x.Id == id);
        if (!issueExists)
        {
            return Results.NotFound("Requested tag does not exists");
        }

        var tagExists = await context.Tags.AnyAsync(x => tagIds.Contains(x.Id));
        if (!tagExists)
        {
            return Results.NotFound("Requested tag does not exists");
        }

        var issueTag = tagIds.Select(x => new IssueTag
        {
            IssueId = id,
            TagId = x
        });
        context.IssueTags.AddRange(issueTag);

        await context.SaveChangesAsync();
        return Results.Ok();
    }
}