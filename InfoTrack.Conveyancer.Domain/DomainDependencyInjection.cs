using System.Reflection;
using InfoTrack.Conveyancer.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Conveyancer.Domain;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<ISettlementService, SettlementService>();
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
    
    
}