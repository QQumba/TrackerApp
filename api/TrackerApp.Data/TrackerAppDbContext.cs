using Microsoft.EntityFrameworkCore;
using TrackerApp.Data.Entities;

namespace TrackerApp.Data;

public class TrackerAppDbContext : DbContext
{
    public TrackerAppDbContext(DbContextOptions<TrackerAppDbContext> options) : base(options)
    {
    }

    public DbSet<Issue> Issue { get; set; } = null!;

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker
            .Entries()
            .Where(e => e is { Entity: AuditEntity, State: EntityState.Added or EntityState.Modified });

        var now = DateTime.UtcNow;
        foreach (var entityEntry in entries)
        {
            ((AuditEntity)entityEntry.Entity).UpdatedDateTime = now;

            if (entityEntry.State == EntityState.Added)
            {
                ((AuditEntity)entityEntry.Entity).CreatedDateTime = now;
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.HasDefaultSchema("tracker_app");
    // }
}