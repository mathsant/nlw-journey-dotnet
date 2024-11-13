namespace Journey.Application.UseCases.Trips.Activities.Complete;

public interface ICompleteActivityForTripUseCase
{
    void Execute(Guid tripId, Guid activityId);
}