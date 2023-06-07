namespace TrackerApp.Data;

public class AuthContext
{
    public string? Login { get; set; }

    public long? EnterpriseId { get; set; }

    public bool IsAuthenticated { get; set; }
}