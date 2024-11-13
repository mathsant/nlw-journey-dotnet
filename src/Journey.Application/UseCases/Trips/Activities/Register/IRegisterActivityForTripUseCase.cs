using Journey.Communication.Requests;
using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.Activities.Register;

public interface IRegisterActivityForTripUseCase
{
    ResponseActivityJson Execute(Guid tripId, RequestRegisterActivityJson request);
}