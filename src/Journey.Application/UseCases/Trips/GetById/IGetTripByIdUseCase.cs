using Journey.Communication.Responses;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.GetById;

public interface IGetTripByIdUseCase
{
    ResponseTripJson Execute(Guid tripId);
}