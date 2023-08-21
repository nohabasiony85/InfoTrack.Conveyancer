using System.Reflection;
using FluentValidation;
using InfoTrack.Conveyancer.Domain.Models.Settlements;
using InfoTrack.Conveyancer.Domain.Services;
using InfoTrack.Conveyancer.Domain.Validators;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Conveyancer.Domain;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ISettlementService, SettlementService>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssemblyContaining<CreateReservationCommandValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


        return services;
    }
    
    
}