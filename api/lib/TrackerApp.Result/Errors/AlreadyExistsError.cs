namespace TrackerApp.Result.Errors;

public class AlreadyExistsError
{
    public AlreadyExistsError()
    {
    }

    public AlreadyExistsError(string? message)
    {
        Message = message;
    }

    public string? Message { get; set; }
}