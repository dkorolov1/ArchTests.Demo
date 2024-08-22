using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ArchUnitNET.Demo.Domain.Checklists;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;

internal sealed class AddChecklistCommandHandler(
    IChecklistsRepository checklistsRepository,
    IMapper mapper) : IRequestHandler<AddChecklistCommand, ErrorOr<Checklist>>
{
    public async Task<ErrorOr<Checklist>> Handle(AddChecklistCommand request, CancellationToken cancellationToken)
    {
        var checklist = mapper.Map<Checklist>(request);
        await checklistsRepository.AddAsync(checklist);

        return checklist;
    }
}