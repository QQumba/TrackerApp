namespace TrackerApp.API.Models;

public record Issue(int Id, string Title, string Author)
{
    public int Id { get; set; } = Id;
}