using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Checklists.Commands.DeleteChecklist;

public sealed record DeleteChecklistCommand(Guid ChecklistId) : IRequest<ErrorOr<Success>>;