using System.Text.Json.Serialization;
using ArchUnitNET.Demo.Domain.Common.Events;

namespace ArchUnitNET.Demo.Domain.Common.Persistence;

public abstract class Entity
{
    public Entity()
    { 
        Id = Guid.Empty;
    }

    public Entity(Guid id) =>
        Id = id;

    public Guid Id { get; private set; }

    [JsonIgnore]
    private readonly List<IDomainEvent> _domainEvents = [];

    [JsonIgnore]
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    public override bool Equals(object? obj) =>
        obj is Entity entity && Id.Equals(entity.Id);

    public bool Equals(Entity? other) =>
        Equals((object?)other);

    public static bool operator ==(Entity left, Entity right) =>
        Equals(left, right);

    public static bool operator !=(Entity left, Entity right) =>
        !Equals(left, right);

    public override int GetHashCode() =>
        Id.GetHashCode();
    
    public void AddDomainEvent(IDomainEvent domainEvent) =>
        _domainEvents.Add(domainEvent);

    public void ClearDomainEvents() =>
        _domainEvents.Clear();
    
    public void SetId(Guid id) =>
        Id = id;
}