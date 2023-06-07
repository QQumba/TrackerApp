namespace TrackerApp.Data.Entities;

public abstract class AuditEntity
{
    public DateTime CreatedDateTime { get; set; }

    public DateTime UpdatedDateTime { get; set; }
}