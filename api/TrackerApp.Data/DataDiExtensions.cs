using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrackerApp.Data;

public static class DataDiExtensions
{
    public static void AddData(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TrackerAppDbContext>(o => o
            .UseNpgsql(configuration.GetConnectionString("Npgsql"))
            .UseSnakeCaseNamingConvention());
    }
}