using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Models;
using TrackerApp.Result;
using TrackerApp.Result.Errors;

namespace TrackerApp.API.ResultTest;

public class ResultTestEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapGet("", GetIssueByAuthor)
            .Produces<Issue>()
            .WithParameter(0, "Author of the issue");
    }

    public static IResult GetIssueByAuthor(string author)
    {
        var producer = new ResultProducer();
        var result = producer.FindIssueByAuthor(author);

        return result.Match(Results.Ok, e => e.ToHttpResult());
    }
}

public class ResultProducer
{
    public Result<Issue, NotFoundError> FindIssueByAuthor(string author)
    {
        var issues = new List<Issue>
        {
            new(1, "test", "nick"),
            new(2, "dont work", "kick")
        };

        var issue = issues.FirstOrDefault(x => x.Author == author);

        if (issue is null)
        {
            return new NotFoundError { Message = $"No issues was created by {author}" };
        }

        return issue;
    }
}