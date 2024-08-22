using ArchUnitNET.Demo.Domain.Requirements;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Requirements.Commands.AddRequirement;

public sealed record AddRequirementCommand(
    Guid ChecklistId,
    string Title,
    string Text) : IRequest<ErrorOr<Requirement>>;
