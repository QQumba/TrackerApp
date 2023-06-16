using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerApp.Data.Entities;

namespace TrackerApp.Data.EntityConfigurations;

public class TagConfiguration : IEntityTypeConfiguration<Tag>
{
    public void Configure(EntityTypeBuilder<Tag> builder)
    {
        builder.HasMany<IssueTag>()
            .WithOne()
            .HasForeignKey(x => x.TagId);
    }
}