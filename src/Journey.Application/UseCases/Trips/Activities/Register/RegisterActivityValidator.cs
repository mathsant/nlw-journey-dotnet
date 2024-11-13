using FluentValidation;
using Journey.Communication.Requests;

namespace Journey.Application.UseCases.Trips.Activities.Register;

public class RegisterActivityValidator : AbstractValidator<RequestRegisterActivityJson>
{
    public RegisterActivityValidator()
    {
        RuleFor(request => request.Name)
            .NotEmpty()
            .WithMessage("Name is required");
    }
}