using System.Collections.Generic;
using System.Linq;
using TrackerApp.API.Features.Tags.Models;
using TrackerApp.Data.Entities;

namespace TrackerApp.API.Features.Issues.Models;

public class IssueDto
{
    public IssueDto(Issue issue)
    {
        Id = issue.Id;
        Title = issue.Title;
        Description = issue.Description;
        Tags = issue.Tags?.Select(x => new TagDto(x));
    }

    public long Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public IEnumerable<TagDto>? Tags { get; set; }
}