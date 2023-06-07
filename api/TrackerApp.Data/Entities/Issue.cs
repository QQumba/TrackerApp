using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerApp.Data.Entities;

[Table("issue")]
public class Issue : AuditEntity
{
    public long IssueId { get; set; }

    public string Title { get; set; } = null!;

    public string Description { get; set; } = null!;
}