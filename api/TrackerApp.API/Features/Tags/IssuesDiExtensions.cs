using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TrackerApp.API.Features.Issues;
using TrackerApp.API.Features.Issues.Models;
using TrackerApp.API.Features.Issues.Validators;

namespace TrackerApp.API.Features.Tags;

public static class TagsDiExtensions
{
    public static void AddTagsFeature(this IServiceCollection services)
    {
        services.AddScoped<TagService>();
    }
}