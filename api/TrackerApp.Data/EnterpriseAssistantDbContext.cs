using Microsoft.EntityFrameworkCore;
using TrackerApp.Data.Entities;

namespace TrackerApp.Data;

public class EnterpriseAssistantDbContext : DbContext
{
    private readonly AuthContext _authContext;

    public EnterpriseAssistantDbContext(AuthContext authContext)
    {
        _authContext = authContext;
    }

    public DbSet<Department> Departments { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>()
            .HasQueryFilter(x => x.EnterpriseId == _authContext.EnterpriseId && _authContext.IsAuthenticated);
    }
}