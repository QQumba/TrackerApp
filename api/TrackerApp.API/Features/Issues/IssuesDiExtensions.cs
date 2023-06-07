using Microsoft.Extensions.DependencyInjection;

namespace TrackerApp.API.Features.Issues;

public static class IssuesDiExtensions
{
    public static void AddIssuesFeature(this IServiceCollection services)
    {
        services.AddScoped<IssuesService>();
    }
}