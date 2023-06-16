using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Tags.Models;

public record TagCreateDto(string Name)
{
    public Tag ToEntity()
    {
        return new Tag
        {
            Name = Name,
        };
    }
}