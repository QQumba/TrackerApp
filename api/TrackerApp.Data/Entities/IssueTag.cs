using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerApp.Data.Entities;

[Table("issue_tag")]
public class IssueTag : AuditEntity
{
    public long Id { get; set; }

    [Column("issue_id")]
    public long IssueId { get; set; }

    [Column("tag_id")]
    public long TagId { get; set; }
}