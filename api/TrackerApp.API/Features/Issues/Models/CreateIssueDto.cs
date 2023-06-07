using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Issues.Models;

public record CreateIssueDto(string Title, string Description)
{
    public Issue ToEntity()
    {
        return new Issue
        {
            Title = Title,
            Description = Description
        };
    }
}