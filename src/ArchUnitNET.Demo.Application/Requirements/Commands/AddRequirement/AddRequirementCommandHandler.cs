using ArchUnitNET.Demo.Application.Requirements.Persistence;
using ArchUnitNET.Demo.Domain.Requirements;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.AddRequirement;

internal sealed class AddRequirementCommandHandler(
    IRequirementsRepository requirementsRepository,
    IMapper mapper) : IRequestHandler<AddRequirementCommand, ErrorOr<Requirement>>
{
    public async Task<ErrorOr<Requirement>> Handle(AddRequirementCommand request, CancellationToken cancellationToken)
    {
        var requirement = mapper.Map<Requirement>(request);
        await requirementsRepository.AddAsync(requirement);

        return requirement;
    }
}