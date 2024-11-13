using Journey.Communication.Requests;
using FluentValidation;
using Journey.Exception;

namespace Journey.Application.UseCases.Trips;

public class TripValidator : AbstractValidator<RequestRegisterTripJson>
{
    public TripValidator()
    {
        RuleFor(trip => trip.Name).NotEmpty().WithMessage(ResourceErrorMessage.NAME_EMPTY);
        RuleFor(trip => trip.StartDate).GreaterThan(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessage.DATE_TRIP_MUST_BE_LATHER_THAN_TODAY);
        RuleFor(trip => trip.EndDate).Must((trip, endDate) => endDate > trip.StartDate)
            .WithMessage(ResourceErrorMessage.END_DATE_TRIP_MUST_BE_LATHER_THAN_START_DATE);
    }
}