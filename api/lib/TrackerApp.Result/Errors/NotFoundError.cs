namespace TrackerApp.Result.Errors;

public class NotFoundError
{
    public NotFoundError()
    {
    }

    public NotFoundError(string message)
    {
        Message = message;
    }

    public string? Message { get; set; }
}