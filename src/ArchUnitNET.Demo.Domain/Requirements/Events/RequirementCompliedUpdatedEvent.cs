using ArchUnitNET.Demo.Domain.Common.Events;

namespace ArchUnitNET.Demo.Domain.Requirements.Events;

public sealed record RequirementCompliedUpdatedEvent(
    Requirement Requirement) : IDomainEvent;