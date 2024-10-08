using MediatR;
using ArchUnitNET.Demo.Domain.Requirements.Events;
using ArchUnitNET.Demo.Application.Checklists.Persistence;
using ArchUnitNET.Demo.Application.Requirements.Persistence;
using ArchUnitNET.Demo.Domain.Checklists.Services.ChecklistProgress;

namespace ArchUnitNET.Demo.Application.Requirements.Events;

public class RequirementAddedEventHandler
    (IRequirementsRepository requirementsRepository,
    IChecklistsRepository checklistsRepository,
    IChecklistProgressService checklistProgressService) : INotificationHandler<RequirementAddedEvent>
{
    public async Task Handle(RequirementAddedEvent notification, CancellationToken cancellationToken)
    {
        var checklist = await checklistsRepository
            .GetByIdAsync(notification.Requirement.ChecklistId)  ?? throw new ApplicationException($"Checklist with id {notification.Requirement.ChecklistId} not found.");
        var checklistRequirements = await requirementsRepository.GetByChecklistIdAsync(notification.Requirement.ChecklistId);
        checklist.Progress = checklistProgressService.CalculateChecklistProgress(checklistRequirements);
        await checklistsRepository.UpdateAsync(checklist);
    }
}