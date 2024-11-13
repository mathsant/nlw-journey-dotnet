using System.Net;

namespace Journey.Exception.ExceptionsBase;

public class ErrorOnValidationException(List<string> errorMessages) : JourneyException(string.Empty)
{
    public override int StatusCode => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return errorMessages;
    }
}