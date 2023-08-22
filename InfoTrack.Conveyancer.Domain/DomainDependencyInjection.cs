using System.Reflection;
using FluentValidation;
using InfoTrack.Conveyancer.Domain.Models.Handlers;
using InfoTrack.Conveyancer.Domain.Repositories;
using InfoTrack.Conveyancer.Domain.Validators;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Conveyancer.Domain;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ISettlementRepository, SettlementRepository>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        services.AddValidatorsFromAssemblyContaining<CreateBookingCommandValidator>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddDbContext<ConveyancerDataContext>(
            options => options.UseInMemoryDatabase("SettlementDb"));

        return services;
    }
}