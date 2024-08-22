using ArchUnitNET.Demo.Application.Requirements.Persistence;
using ArchUnitNET.Demo.Domain.Requirements;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.UpdateCompliedState;

internal sealed class UpdateCompliedStateCommandHandler
    (IRequirementsRepository requirementsRepository) : IRequestHandler<UpdateCompliedStateCommand, ErrorOr<Requirement>>
{
    public async Task<ErrorOr<Requirement>> Handle(UpdateCompliedStateCommand request, CancellationToken cancellationToken)
    {
        var requirement = await requirementsRepository
            .GetByIdAsync(request.RequirementId);

        if (requirement is null)
        {
            return Error.NotFound("Requirement not found.");
        }

        requirement.SetIsComplied(request.IsComplied);

        await requirementsRepository
            .UpdateAsync(requirement);

        return requirement;
    }
}


