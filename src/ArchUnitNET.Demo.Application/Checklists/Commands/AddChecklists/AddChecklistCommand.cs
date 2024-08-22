using ErrorOr;
using MediatR;
using ArchUnitNET.Demo.Domain.Checklists;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;

public sealed record AddChecklistCommand(
    string Name,
    string Description) : IRequest<ErrorOr<Checklist>>;