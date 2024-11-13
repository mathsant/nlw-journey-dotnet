using Journey.Communication.Responses;

namespace Journey.Application.UseCases.Trips.GetAll;

public interface IGetAllTripsUseCase
{
    ResponseTripsJson Execute();
}