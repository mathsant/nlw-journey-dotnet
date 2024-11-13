using FluentValidation.Results;
using Journey.Communication.Enums;
using Journey.Communication.Requests;
using Journey.Communication.Responses;
using Journey.Exception;
using Journey.Exception.ExceptionsBase;
using Journey.Infrastructure;
using Journey.Infrastructure.Entities;

namespace Journey.Application.UseCases.Trips.Activities.Register;

public class RegisterActivityForTripUseCase : IRegisterActivityForTripUseCase
{
    public ResponseActivityJson Execute(Guid tripId, RequestRegisterActivityJson request)
    {
        var dbContext = new JourneyDbContext();
        
        var tripFound = dbContext.Trips.FirstOrDefault(trip => trip.Id == tripId);
        
        Validate(tripFound, request);

        var entity = new Activity
        {
            TripId = tripId,
            Name = request.Name,
            Date = request.Date,
        };
        
        dbContext.Activities.Add(entity);
        
        dbContext.SaveChanges();

        return new ResponseActivityJson
        {
            Id = entity.Id,
            Name = entity.Name,
            Date = entity.Date,
            Status = (ActivityStatus)entity.Status,
        };
    }

    private static void Validate(Trip? trip, RequestRegisterActivityJson request)
    {
        if (trip is null) throw new NotFoundException(ResourceErrorMessage.TRIP_NOT_FOUND);

        var validator = new RegisterActivityValidator();
        
        var result = validator.Validate(request);
        
        if ((request.Date >= trip.StartDate && request.Date <= trip.EndDate) == false)
            result.Errors.Add(new ValidationFailure("Date", "The date must be between the trip date."));
        
        if (result.IsValid) return;
        
        var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

        throw new ErrorOnValidationException(errorMessages);

    }
}