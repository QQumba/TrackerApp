namespace TrackerApp.Data.Entities;

public class Department
{
    public long DepartmentId { get; set; }

    public long EnterpriseId { get; set; }

    public string Name { get; set; } = null!;
}