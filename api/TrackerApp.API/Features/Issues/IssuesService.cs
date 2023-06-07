using System.Collections.Generic;
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

    public async Task<Issue> CreateIssue(CreateIssueDto issueDto)
    {
        var issue = _context.Issue.Add(issueDto.ToEntity()).Entity;
        await _context.SaveChangesAsync();

        return issue;
    }

    public async Task<List<Issue>> GetAllIssues()
    {
        return await _context.Issue.ToListAsync();
    }

    public async Task<Result<Issue, NotFoundError>> GetIssueById(long issueId)
    {
        var issue = await _context.Issue.FirstOrDefaultAsync(x => x.IssueId == issueId);
        if (issue is null)
        {
            return new NotFoundError($"Issue with id: {issueId} not found");
        }

        return issue;
    }
}