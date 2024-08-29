using ArchUnitNET.Demo.Domain.Common.Persistence;

namespace ArchUnitNET.Demo.Domain.Checklists;

public class Checklist : Entity
{
    public Checklist(Guid id, string name, string description, float progress) : base(id)
    {
        Name = name;
        Description = description;
        Progress = progress;
    }

    public Checklist() : base(Guid.NewGuid())
    {
        Name = null!;
        Description = null!;
        Progress = 0;
    }

    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public float Progress { get; set; } = 0;
}