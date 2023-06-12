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

    public async Task<Issue> CreateIssue(IssueCreateDto dto)
    {
        var issue = _context.Issue.Add(dto.ToEntity()).Entity;
        await _context.SaveChangesAsync();

        return issue;
    }

    public async Task<List<Issue>> GetAllIssues()
    {
        return await _context.Issue.ToListAsync();
    }

    public async Task<Result<Issue, NotFoundError>> GetIssueById(long id)
    {
        var issue = await _context.Issue.FirstOrDefaultAsync(x => x.Id == id);
        if (issue is null)
        {
            return new NotFoundError($"Issue with id: {id} not found");
        }

        return issue;
    }

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