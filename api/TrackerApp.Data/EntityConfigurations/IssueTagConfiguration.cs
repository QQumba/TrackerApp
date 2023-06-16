using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrackerApp.Data.Entities;

namespace TrackerApp.Data.EntityConfigurations;

public class IssueTagConfiguration : IEntityTypeConfiguration<IssueTag>
{
    public void Configure(EntityTypeBuilder<IssueTag> builder)
    {
        return;
        
        builder.ToTable("issue_tag");
        
        builder.HasOne<Issue>()
            .WithMany()
            .HasForeignKey("issue_id");

        builder.HasOne<Tag>()
            .WithMany()
            .HasForeignKey("tag_id");
    }
}