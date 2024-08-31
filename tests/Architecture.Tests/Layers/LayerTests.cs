using ArchUnitNET.xUnit;
using ArchUnitNET.Fluent;

namespace Architecture.Tests.Layers;

public class LayerTests : ArchBaseTest
{
    [Fact]
    public void PresentationLayer_Should_NotDependOnInfrastructureOrDomainLayers()
    {
        ArchRuleDefinition
            .Types()
            .That()
            .Are(PresentationLayer)
            .Should()
            .NotDependOnAny(InfrastructureLayer)
            .AndShould()
            .NotDependOnAny(DomainLayer)
            .Check(Architecture);
    }

    [Fact]
    public void ApplicationLayer_Should_NotDependOnInfrastructureOrPresentationLayers()
    {
        ArchRuleDefinition
            .Types()
            .That()
            .Are(ApplicationLayer)
            .Should()
            .NotDependOnAny(InfrastructureLayer)
            .AndShould()
            .NotDependOnAny(PresentationLayer)
            .Check(Architecture);
    }

    [Fact]
    public void DomainLayer_Should_NotDependOnAnyOtherLayer()
    {
        ArchRuleDefinition
            .Types()
            .That()
            .Are(DomainLayer)
            .Should()
            .NotDependOnAny(InfrastructureLayer)
            .AndShould()
            .NotDependOnAny(ApplicationLayer)
            .AndShould()
            .NotDependOnAny(PresentationLayer)
            .Check(Architecture);
    }

    [Fact]
    public void InfrastructureLayer_Should_NotDependOnPresentationLayer()
    {
        ArchRuleDefinition
            .Types()
            .That()
            .Are(InfrastructureLayer)
            .Should()
            .NotDependOnAny(PresentationLayer)
            .Check(Architecture);
    }
}