using ArchUnitNET.Demo.Domain.Requirements;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.UpdateCompliedState;

public sealed record UpdateCompliedStateCommand(
    Guid RequirementId,
    bool IsComplied) : IRequest<ErrorOr<Requirement>>;