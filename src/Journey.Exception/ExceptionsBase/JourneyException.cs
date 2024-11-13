namespace Journey.Exception.ExceptionsBase;

public abstract class JourneyException(string message) : SystemException(message)
{
    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();
}