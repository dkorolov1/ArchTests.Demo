using ArchUnitNET.Demo.Api;
using ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;
using ArchUnitNET.Demo.Contracts.Checklists;
using ArchUnitNET.Demo.Domain.Common.Persistence;
using ArchUnitNET.Demo.Infrastructure.Checklists.Persistence;
using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.Loader;
using Assembly = System.Reflection.Assembly;

namespace Architecture.Tests;

public abstract class ArchBaseTest
{
    protected static readonly Assembly DomainAssembly = typeof(Entity).Assembly;
    protected static readonly Assembly ApplicationAssembly = typeof(AddChecklistCommand).Assembly;
    protected static readonly Assembly InfrastructureAssembly = typeof(ChecklistsRepository).Assembly;
    protected static readonly Assembly ApiAssembly = typeof(DependencyInjection).Assembly;
    protected static readonly Assembly ContractsAssembly = typeof(AddChecklistRequest).Assembly;

    protected static readonly IObjectProvider<IType> DomainLayer = 
        ArchRuleDefinition.Types().That().ResideInAssembly(DomainAssembly).As("Domain Layer");
    protected static readonly IObjectProvider<IType> ApplicationLayer = 
        ArchRuleDefinition.Types().That().ResideInAssembly(ApplicationAssembly).As("Application Layer");
    protected static readonly IObjectProvider<IType> InfrastructureLayer = 
        ArchRuleDefinition.Types().That().ResideInAssembly(InfrastructureAssembly).As("Infrastructure Layer");
    protected static readonly IObjectProvider<IType> PresentationLayer = 
        ArchRuleDefinition.Types().That().ResideInAssembly(ApiAssembly).Or().ResideInAssembly(ContractsAssembly).As("Presentation Layer");

    protected static readonly ArchUnitNET.Domain.Architecture Architecture = new ArchLoader()
        .LoadAssemblies(
            DomainAssembly,
            ApplicationAssembly,
            InfrastructureAssembly,
            ApiAssembly,
            ContractsAssembly)
        .Build();
}