using Journey.Application.UseCases.Trips.Activities.Complete;
using Journey.Application.UseCases.Trips.Activities.Delete;
using Journey.Application.UseCases.Trips.Activities.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.GetAll;
using Journey.Application.UseCases.Trips.GetById;
using Journey.Application.UseCases.Trips.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Journey.Application.UseCases;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddTripsUseCases(services);
        AddActivityUseCases(services);
    }

    private static void AddTripsUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterTripUseCase, RegisterTripUseCase>();
        services.AddScoped<IGetAllTripsUseCase, GetAllTripsUseCase>();
        services.AddScoped<IGetTripByIdUseCase, GetTripByIdUseCase>();
        services.AddScoped<IDeleteTripByIdUseCase, DeleteTripByIdUseCase>();
    }

    private static void AddActivityUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterActivityForTripUseCase, RegisterActivityForTripUseCase>();
        services.AddScoped<ICompleteActivityForTripUseCase, CompleteActivityForTripUseCase>();
        services.AddScoped<IDeleteActivityByIdUseCase, DeleteActivityByIdUseCase>();
    }
}