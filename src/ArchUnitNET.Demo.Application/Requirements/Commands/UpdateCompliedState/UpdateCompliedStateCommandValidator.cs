using FluentValidation;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.UpdateCompliedState;

internal sealed class UpdateCompliedStateCommandValidator : AbstractValidator<UpdateCompliedStateCommand>
{
    public UpdateCompliedStateCommandValidator()
    {
        RuleFor(v => v.RequirementId)
            .NotEmpty().WithMessage("RequirementId is required.");
    }
}