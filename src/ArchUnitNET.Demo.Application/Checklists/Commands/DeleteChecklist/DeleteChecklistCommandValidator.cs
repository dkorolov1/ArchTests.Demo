using FluentValidation;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.DeleteChecklist;

internal sealed class DeleteChecklistCommandValidator : AbstractValidator<DeleteChecklistCommand>
{
    public DeleteChecklistCommandValidator()
    {
        RuleFor(v => v.ChecklistId)
            .NotEmpty().WithMessage("ChecklistId is required.");
    }
}