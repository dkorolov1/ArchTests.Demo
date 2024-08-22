using ArchUnitNET.Domain.Extensions;
using ArchUnitNET.xUnit;
using FluentAssertions;

namespace Architecture.Tests.Domain;

public partial class ArchUnitDomainTests
{
    [Fact]
    public void DomainEntities_Should_ResideInDomainLayer()
    {
        _domainEntityClasses
            .Should()
            .ResideInAssembly(DomainAssembly)
            .Check(Architecture);
    }

    [Fact]
    public void DomainEntities_Should_HavePublicParameterlessConstructor()
    {
        var entityTypes = _domainEntityClasses
            .GetObjects(Architecture)
            .All(entityType =>
                 entityType
                    .GetConstructors()
                    // Check if there is a public parameterless constructor
                    .Any(ctor => ctor.Visibility == ArchUnitNET.Domain.Visibility.Public && !ctor.Parameters.Any())
            )
            .Should()
            .BeTrue();
    }
}