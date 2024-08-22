using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ArchUnitNET.Demo.Application.Requirements.Persistence;
using ArchUnitNET.Demo.Infrastructure.Checklists.Persistence;
using ArchUnitNET.Demo.Infrastructure.Requirements.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace ArchUnitNET.Demo.Infrastructure;

public static class DependencyInjestion
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services) =>
        services.AddPersistence();

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        //Checklists
        services.AddSingleton<IChecklistsRepository, ChecklistsRepository>();

        //Requirements
        services.AddSingleton<IRequirementsRepository, RequirementsRepository>();

        return services;
    }   
}
