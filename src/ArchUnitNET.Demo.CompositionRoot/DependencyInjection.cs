using ArchUnitNET.Demo.Application;
using ArchUnitNET.Demo.Domain;
using ArchUnitNET.Demo.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace ArchUnitNET.Demo.CompositionRoot;

public static class DependencyInjection
{
    public static IServiceCollection AddAppLayers(this IServiceCollection services) => 
        services
            .AddDomain()
            .AddApplication()
            .AddInfrastructure();
}
