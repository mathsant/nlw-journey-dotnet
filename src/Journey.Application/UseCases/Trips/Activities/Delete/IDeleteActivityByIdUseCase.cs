namespace Journey.Application.UseCases.Trips.Activities.Delete;

public interface IDeleteActivityByIdUseCase
{
    void Execute(Guid activityId, Guid tripId);
}