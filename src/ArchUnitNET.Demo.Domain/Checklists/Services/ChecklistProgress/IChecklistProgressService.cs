using ArchUnitNET.Demo.Domain.Requirements;

namespace ArchUnitNET.Demo.Domain.Checklists.Services.ChecklistProgress;

internal interface IChecklistProgressService
{
    float CalculateChecklistProgress(IEnumerable<Requirement> requirements);
}