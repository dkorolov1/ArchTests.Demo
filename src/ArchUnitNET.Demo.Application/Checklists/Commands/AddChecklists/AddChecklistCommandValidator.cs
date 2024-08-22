using FluentValidation;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;

internal sealed class AddChecklistCommandValidator : AbstractValidator<AddChecklistCommand>
{
    public AddChecklistCommandValidator()
    {
        RuleFor(v => v.Name)
            .MaximumLength(200).WithMessage("Name is too long.")
            .NotEmpty().WithMessage("Name is required.");

        RuleFor(v => v.Description)
            .MaximumLength(1000).WithMessage("Description is too long.")
            .NotEmpty().WithMessage("Description is required.");
    }
}