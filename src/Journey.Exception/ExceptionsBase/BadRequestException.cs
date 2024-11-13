using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class BadRequestException : JourneyException
{
    public BadRequestException(string message) : base(message) {}

    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}