using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TrackerApp.API.Features.Issues.Models;
using TrackerApp.API.Features.Issues.Validators;

namespace TrackerApp.API.Features.Issues;

public static class IssuesDiExtensions
{
    public static void AddIssuesFeature(this IServiceCollection services)
    {
        services.AddScoped<IValidator<IssueCreateDto>, IssueValidator>();
        services.AddScoped<IssuesService>();
    }
}