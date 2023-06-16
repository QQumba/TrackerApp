using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerApp.Data.Entities;

namespace TrackerApp.Data.EntityConfigurations;

public class IssueConfiguration : IEntityTypeConfiguration<Issue>
{
    public void Configure(EntityTypeBuilder<Issue> builder)
    {
        builder.HasMany<IssueTag>()
            .WithOne()
            .HasForeignKey(x => x.IssueId);

        builder.HasMany(x => x.Tags)
            .WithMany()
            .UsingEntity<IssueTag>();
    }
}