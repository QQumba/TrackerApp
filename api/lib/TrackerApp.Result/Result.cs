namespace TrackerApp.Result;

public class Result<TValue, TError>
{
    private readonly TValue? _value;
    private readonly TError? _error;

    public Result(TValue value)
    {
        _value = value;
        IsSuccessful = true;
    }

    public Result(TError error)
    {
        _error = error;
        IsSuccessful = false;
    }

    public bool IsSuccessful { get; }

    public TMatch Match<TMatch>(Func<TValue, TMatch> success, Func<TError, TMatch> error)
    {
        return IsSuccessful ? success(_value!) : error(_error!);
    }

    public static implicit operator Result<TValue, TError>(TValue value) => new(value);

    public static implicit operator Result<TValue, TError>(TError error) => new(error);
}