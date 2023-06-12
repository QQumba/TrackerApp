using FluentValidation;
using TrackerApp.API.Features.Issues.Models;

namespace TrackerApp.API.Features.Issues.Validators;

public class IssueValidator : AbstractValidator<IssueCreateDto>
{
    public IssueValidator()
    {
        RuleFor(x => x.Title).NotNull();
        RuleFor(x => x.Title).MinimumLength(3);

        RuleFor(x => x.Description).NotNull();
        RuleFor(x => x.Description).MinimumLength(3);
    }
}