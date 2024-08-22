using FluentValidation;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.AddRequirement;

internal sealed class AddRequirementCommandValidator : AbstractValidator<AddRequirementCommand>
{
    public AddRequirementCommandValidator()
    {
        RuleFor(v => v.ChecklistId)
            .NotEmpty().WithMessage("ChecklistId is required.");

        RuleFor(v => v.Title)
            .MaximumLength(200).WithMessage("Title is too long.")
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(v => v.Text)
            .MaximumLength(1000).WithMessage("Text is too long.")
            .NotEmpty().WithMessage("Text is required.");
    }
}