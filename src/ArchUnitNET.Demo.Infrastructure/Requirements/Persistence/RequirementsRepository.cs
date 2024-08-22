using MediatR;
using ArchUnitNET.Demo.Application.Requirements.Persistence;
using ArchUnitNET.Demo.Domain.Requirements;
using ArchUnitNET.Demo.Infrastructure.Common.Persistence;

namespace ArchUnitNET.Demo.Infrastructure.Requirements.Persistence;

public class RequirementsRepository(IPublisher mediator) : BaseRepository<Requirement>(mediator), IRequirementsRepository
{
    public Task<IEnumerable<Requirement>> GetByChecklistIdAsync(Guid checklistId) =>
        Task.Run(() => Items.Where(r => r.ChecklistId == checklistId));
}