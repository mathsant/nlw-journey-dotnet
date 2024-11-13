using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class NotFoundException(string message) : JourneyException(message)
{
    public override int StatusCode => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}