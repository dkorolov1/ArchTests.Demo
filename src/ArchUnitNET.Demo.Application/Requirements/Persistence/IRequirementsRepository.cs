using ArchUnitNET.Demo.Application.Common.Persistence;
using ArchUnitNET.Demo.Domain.Requirements;

namespace  ArchUnitNET.Demo.Application.Requirements.Persistence;

public interface IRequirementsRepository : IBaseRepository<Requirement>
{
    Task<IEnumerable<Requirement>> GetByChecklistIdAsync(Guid checklistId);
}