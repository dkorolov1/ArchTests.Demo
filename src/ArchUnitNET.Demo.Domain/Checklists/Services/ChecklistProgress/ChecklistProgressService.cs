using ArchUnitNET.Demo.Domain.Requirements;

namespace ArchUnitNET.Demo.Domain.Checklists.Services.ChecklistProgress;

public class ChecklistProgressService : IChecklistProgressService
{
    public float CalculateChecklistProgress(IEnumerable<Requirement> requirements) =>
        (float)requirements.Count(r => r.IsComplied) / requirements.Count();
}