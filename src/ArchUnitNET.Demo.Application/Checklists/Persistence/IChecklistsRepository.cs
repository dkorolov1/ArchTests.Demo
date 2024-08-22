using ArchUnitNET.Demo.Application.Common.Persistence;
using ArchUnitNET.Demo.Domain.Checklists;

namespace ArchUnitNET.Demo.Application.Checklists.Persistence;

public interface IChecklistsRepository : IBaseRepository<Checklist>
{
}