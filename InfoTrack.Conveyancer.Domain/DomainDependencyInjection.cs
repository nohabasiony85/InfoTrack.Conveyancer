using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace InfoTrack.Conveyancer.Domain;

public static class DomainDependencyInjection
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

        return services;
    }
}