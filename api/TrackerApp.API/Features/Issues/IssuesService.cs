using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackerApp.API.Features.Issues.Models;
using TrackerApp.Data;
using TrackerApp.Data.Entities;
using TrackerApp.Result;
using TrackerApp.Result.Errors;

namespace TrackerApp.API.Features.Issues;

public class IssuesService
{
    private readonly TrackerAppDbContext _context;

    public IssuesService(TrackerAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<IssueDto, NotFoundError>> CreateIssue(IssueCreateDto dto)
    {
        var issue = _context.Issue.Add(dto.ToEntity()).Entity;

        var tagsExists = await _context.Tags.AnyAsync(x => dto.TagIds.Contains(x.Id));
        if (!tagsExists)
        {
            return new NotFoundError("Specified tags do not exist");
        }

        var issueTags = dto.TagIds.Select(x =>
            new IssueTag { IssueId = issue.Id, TagId = x });
        _context.IssueTags.AddRange(issueTags);

        await _context.SaveChangesAsync();

        return new IssueDto(issue);
    }

    public async Task<IEnumerable<IssueDto>> GetAllIssues()
    {
        var issues = await _context.Issue.Include(x => x.Tags).ToListAsync();

        return issues.Select(x => new IssueDto(x));
    }

    public async Task<Result<IssueDto, NotFoundError>> GetIssueById(long id)
    {
        var issue = await _context.Issue.FirstOrDefaultAsync(x => x.Id == id);
        if (issue is null)
        {
            return new NotFoundError($"Issue with id: {id} not found");
        }

        return new IssueDto(issue);
    }

    // TODO: why return int???
    public async Task<Result<int, NotFoundError>> DeleteIssue(long id)
    {
        var deletedRecordsCount = await _context.Issue.Where(x => x.Id == id).ExecuteDeleteAsync();
        if (deletedRecordsCount == 0)
        {
            return new NotFoundError($"Issue with id: {id} not found");
        }

        return deletedRecordsCount;
    }
}