using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ArchUnitNET.Demo.Domain.Checklists;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Checklists.Queries.GetChecklists;

internal sealed class GetChecklistsQueryHandler
    (IChecklistsRepository checklistsRepository) : IRequestHandler<GetChecklistsQuery, ErrorOr<IEnumerable<Checklist>>>
{
    public async Task<ErrorOr<IEnumerable<Checklist>>> Handle(GetChecklistsQuery request, CancellationToken cancellationToken)
    {
        var checklists = await checklistsRepository.GetAllAsync();
        return ErrorOrFactory.From(checklists);
    }
}