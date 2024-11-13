using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;

namespace Journey.Application.UseCases.Trips.Activities.Delete;

public class DeleteActivityByIdUseCase : IDeleteActivityByIdUseCase
{
    public void Execute(Guid activityId, Guid tripId)
    {
        var dbContext = new JourneyDbContext();
        
        var activity = dbContext.Activities.FirstOrDefault(activity => activity.Id == activityId && activity.TripId == tripId);
        
        if (activity is null) throw new NotFoundException("Activity not found.");
        
        dbContext.Activities.Remove(activity);
        
        dbContext.SaveChanges();
    }
}