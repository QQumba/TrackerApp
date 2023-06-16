using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TrackerApp.API.Features.Tags.Models;
using TrackerApp.Data;
using TrackerApp.Data.Entities;
using TrackerApp.Result;
using TrackerApp.Result.Errors;

namespace TrackerApp.API.Features.Tags;

public class TagService
{
    private readonly TrackerAppDbContext _context;

    public TagService(TrackerAppDbContext context)
    {
        _context = context;
    }

    public async Task<Result<TagDto, AlreadyExistsError>> CreateTag(TagCreateDto dto)
    {
        var nameAlreadyTaken = await _context.Tags.AnyAsync(x => x.Name == dto.Name);
        if (nameAlreadyTaken)
        {
            return new AlreadyExistsError($"Tag with name: {dto.Name} already exists");
        }

        var tag = _context.Tags.Add(dto.ToEntity()).Entity;
        await _context.SaveChangesAsync();

        return new TagDto(tag);
    }

    public async Task<List<TagDto>> GetAllTags()
    {
        return await _context.Tags.Select(x => new TagDto(x.Id, x.Name)).ToListAsync();
    }
}