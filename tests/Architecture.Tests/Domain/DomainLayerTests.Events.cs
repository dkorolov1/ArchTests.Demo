using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;

namespace Architecture.Tests.Domain;

public partial class DomainLayerTests
{
    [Fact]
    public void DomainEvents_Should_ResideInDomainLayer()
    {
        _domainEventClasses
            .Should()
            .ResideInAssembly(DomainAssembly)
            .Check(Architecture);
    }

    [Fact]
    public void DomainEvents_Should_HaveEventPostfix()
    {
        _domainEventClasses
            .Should()
            .HaveNameEndingWith("Event")
            .Check(Architecture);
    }

    [Fact]
    public void DomainEvents_Should_BeSealed()
    {
        _domainEventClasses
            .Should()
            .BeSealed()
            .Check(Architecture);
    }

    [Fact]
    public void DomainEvents_Should_BeImmutable()
    {
        _domainEventClasses
            .Should()
            .BeImmutable()
            .Check(Architecture);
    }

    [Fact]
    public void DomainEvents_Should_NotBeUsedOutsideDomainLayer_Or_EventHandlers()
    {
        ArchRuleDefinition
            .Classes()
            .That()
            .DoNotResideInAssembly(DomainAssembly)
            .And()
            .DoNotHaveNameEndingWith("EventHandler")
            .Should()
            .NotDependOnAny(_domainEventClasses)
            .Check(Architecture);
    }
}