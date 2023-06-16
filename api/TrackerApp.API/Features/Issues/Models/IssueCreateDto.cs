using System.Collections.Generic;
using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Issues.Models;

public record IssueCreateDto(string Title, string Description, List<long> TagIds)
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