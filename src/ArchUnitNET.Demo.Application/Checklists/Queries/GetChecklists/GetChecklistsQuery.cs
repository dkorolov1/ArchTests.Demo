using ArchUnitNET.Demo.Domain.Checklists;
using ErrorOr;
using MediatR;

namespace ArchUnitNET.Demo.Application.Checklists.Queries.GetChecklists;

public sealed record GetChecklistsQuery() : IRequest<ErrorOr<IEnumerable<Checklist>>>;