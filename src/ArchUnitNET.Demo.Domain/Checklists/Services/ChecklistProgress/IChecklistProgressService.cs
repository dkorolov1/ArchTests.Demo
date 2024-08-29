using ArchUnitNET.Demo.Domain.Requirements;

namespace ArchUnitNET.Demo.Domain.Checklists.Services.ChecklistProgress;

public interface IChecklistProgressService
{
    float CalculateChecklistProgress(IEnumerable<Requirement> requirements);
}