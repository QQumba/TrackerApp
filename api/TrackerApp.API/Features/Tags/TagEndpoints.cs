using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Features.Tags.Models;

namespace TrackerApp.API.Features.Tags;

public class TagEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapPost("", CreateTag);
        
        builder.MapGet("", GetAllTags);
    }

    private async Task<IResult> CreateTag(TagCreateDto tagCreateDto, TagService service)
    {
        var result = await service.CreateTag(tagCreateDto);
        return result.Match(tag => Results.Created($"{tag.Id}", tag), e => Results.BadRequest(e.Message));
    }

    private async Task<IResult> GetAllTags(TagService service)
    {
        var tags = await service.GetAllTags();
        return Results.Ok(tags);
    }
}