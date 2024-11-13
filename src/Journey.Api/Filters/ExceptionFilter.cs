using Journey.Communication.Responses;
using Journey.Exception.ExceptionsBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Journey.Api.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is JourneyException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnkwnownError(context);
        }
    }

    private void HandleProjectException(ExceptionContext context)
    {
        var journeyException = context.Exception as JourneyException;
        var errorResponse = new ResponseErrorJson(journeyException!.GetErrors());
        
        context.HttpContext.Response.StatusCode = journeyException.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private void ThrowUnkwnownError(ExceptionContext context)
    {
        var errorResponse = new ResponseErrorJson("Unkwnown Error");
        
        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}