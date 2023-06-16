using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Tags.Models;

public record TagDto(long Id, string Name)
{
    public TagDto(Tag tag) : this(tag.Id, tag.Name)
    {
    }
}