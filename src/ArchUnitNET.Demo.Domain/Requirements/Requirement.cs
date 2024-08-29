using ArchUnitNET.Demo.Domain.Common.Persistence;
using ArchUnitNET.Demo.Domain.Requirements.Events;

namespace ArchUnitNET.Demo.Domain.Requirements;

public class Requirement : Entity
{
    public Requirement() : base(Guid.NewGuid())
    {
        Title = null!;
        Text = null!;
        IsComplied = false;

        AddDomainEvent(new RequirementAddedEvent(this));
    }

    public Requirement(Guid id, Guid checklistId, string title, string text, bool isComplied) : base(id)
    {
        ChecklistId = checklistId;
        Title = title;
        Text = text;
        IsComplied = isComplied;

        AddDomainEvent(new RequirementAddedEvent(this));
    }

    public void SetIsComplied(bool isComplied)
    {
        IsComplied = isComplied;
        AddDomainEvent(new RequirementCompliedUpdatedEvent(this));
    }

    public Guid ChecklistId { get; private set; }
    public string Title { get; private set; } = null!;
    public string Text { get; private set; } = null!;
    public bool IsComplied { get; private set; } = false;
}
