using ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;

namespace ArchUnitNET.Demo.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddProblemDetails();

        return services;
    }
}
