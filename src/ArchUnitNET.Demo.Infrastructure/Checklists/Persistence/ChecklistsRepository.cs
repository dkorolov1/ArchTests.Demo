using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ArchUnitNET.Demo.Domain.Checklists;
using ArchUnitNET.Demo.Infrastructure.Common.Persistence;
using MediatR;

namespace ArchUnitNET.Demo.Infrastructure.Checklists.Persistence;

public class ChecklistsRepository(IPublisher mediator) : BaseRepository<Checklist>(mediator), IChecklistsRepository
{

}
