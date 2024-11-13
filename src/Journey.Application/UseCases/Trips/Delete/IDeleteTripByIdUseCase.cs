namespace Journey.Application.UseCases.Trips.Delete;

public interface IDeleteTripByIdUseCase
{
    void Execute(Guid tripId);
}