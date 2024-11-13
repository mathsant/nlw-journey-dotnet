using Journey.Application.UseCases.Trips.Activities.Complete;
using Journey.Application.UseCases.Trips.Activities.Delete;
using Journey.Application.UseCases.Trips.Activities.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Journey.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TripsController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseShortTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public IActionResult Register(
        [FromServices] IRegisterTripUseCase useCase,
        [FromBody] RequestRegisterTripJson request
        )
    {
        var response = useCase.Execute(request);
        return Created(string.Empty, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ResponseTripsJson), StatusCodes.Status200OK)]
    public IActionResult GetAll([FromServices] IGetAllTripsUseCase useCase)
    {
        var response = useCase.Execute();
        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    [ProducesResponseType(typeof(ResponseTripJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult GetById(
        [FromServices] IGetTripByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        var response = useCase.Execute(id);
        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult Delete(
        [FromServices] IDeleteTripByIdUseCase useCase,
        [FromRoute] Guid id)
    {
        useCase.Execute(id);
        return NoContent();
    }

    [HttpPost]
    [Route("{tripId}/activity")]
    [ProducesResponseType(typeof(ResponseActivityJson), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult RegisterActivity(
        [FromServices] IRegisterActivityForTripUseCase useCase,
        [FromRoute] Guid tripId,
        [FromBody] RequestRegisterActivityJson request)
    {
        var result = useCase.Execute(tripId, request);
        return Created(string.Empty, result);
    }

    [HttpPut]
    [Route("{tripId}/activity/{activityId}/complete")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
    public IActionResult CompleteActivity(
        [FromServices] ICompleteActivityForTripUseCase useCase,
        [FromRoute] Guid tripId,
        [FromRoute] Guid activityId)
    {
        useCase.Execute(tripId, activityId);
        return NoContent();
    }

    [HttpPut]
    [Route("{tripId}/activity/{activityId}")]
    public IActionResult DeleteActivity(
        [FromServices] IDeleteActivityByIdUseCase useCase,
        [FromRoute] Guid tripId,
        [FromRoute] Guid activityId)
    {
        useCase.Execute(activityId: activityId, tripId: tripId);
        return NoContent();
    }
    
}