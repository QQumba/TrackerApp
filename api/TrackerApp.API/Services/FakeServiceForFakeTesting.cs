namespace TrackerApp.API.Services;

public class FakeServiceForFakeTesting
{
    public string SayThings(string text)
    {
        return text + text;
    }
    
    public string Echo(string text)
    {
        return text;
    }
}