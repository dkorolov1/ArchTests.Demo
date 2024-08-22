using Microsoft.Extensions.DependencyInjection;
using ArchUnitNET.Demo.Domain.Checklists.Services.ChecklistProgress;

namespace ArchUnitNET.Demo.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomain(this IServiceCollection services) =>
        services
            .AddServices();

    private static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IChecklistProgressService, ChecklistProgressService>();
        return services;
    }
}