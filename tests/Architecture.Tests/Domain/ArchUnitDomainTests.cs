using ArchUnitNET.Fluent;
using ArchUnitNET.Demo.Domain.Common.Events;
using ArchUnitNET.Demo.Domain.Common.Persistence;
using ArchUnitNET.Fluent.Syntax.Elements.Types.Classes;

namespace Architecture.Tests.Domain;

public partial class ArchUnitDomainTests : ArchitectureBaseTest
{
    private readonly GivenClassesConjunction _domainEventClasses = ArchRuleDefinition
            .Classes()
            .That()
            .ImplementInterface(typeof(IDomainEvent));

    private readonly GivenClassesConjunction _domainEntityClasses = ArchRuleDefinition
            .Classes()
            .That()
            .AreAssignableTo(typeof(Entity));
}
