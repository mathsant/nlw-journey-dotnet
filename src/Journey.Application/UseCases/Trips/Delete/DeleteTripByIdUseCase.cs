using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Journey.Application.UseCases.Trips.Delete;

public class DeleteTripByIdUseCase : IDeleteTripByIdUseCase
{
    public void Execute(Guid tripId)
    {
        var dbContext = new JourneyDbContext();
        
        var trip = dbContext.Trips.Include(trip => trip.Activities).FirstOrDefault(trip => trip.Id == tripId);
        
        if (trip is null) throw new NotFoundException("Trip not found.d");
        
        dbContext.Trips.Remove(trip);
        
        dbContext.SaveChanges();
    }
}