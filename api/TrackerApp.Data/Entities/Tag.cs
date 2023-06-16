using System.ComponentModel.DataAnnotations.Schema;

namespace TrackerApp.Data.Entities;

[Table("tag")]
public class Tag : AuditEntity
{
    public long Id { get; set; }

    public string Name { get; set; } = null!;
}