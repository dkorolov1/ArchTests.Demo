using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.DeleteChecklist;

internal sealed class DeleteChecklistCommandHandler
    (IChecklistsRepository checklistsRepository) : IRequestHandler<DeleteChecklistCommand, ErrorOr<Success>>
{
    public async Task<ErrorOr<Success>> Handle(DeleteChecklistCommand request, CancellationToken cancellationToken)
    {
        var checklist = await checklistsRepository
            .GetByIdAsync(request.ChecklistId);
        
        if (checklist is null)
        {
            return Error.NotFound("Checklist not found.");
        }

        await checklistsRepository
            .DeleteAsync(checklist);

        return Result.Success;
    }
}

    
