using MediatR;
using MapsterMapper;
using ArchUnitNET.Demo.Api;
using ArchUnitNET.Demo.CompositionRoot;
using ArchUnitNET.Demo.Contracts.Checklists;
using ArchUnitNET.Demo.Contracts.Requirements;
using ArchUnitNET.Demo.Application.Checklists.Commands.AddChecklists;
using ArchUnitNET.Demo.Application.Checklists.Commands.DeleteChecklist;
using ArchUnitNET.Demo.Application.Requirements.Commands.AddRequirement;
using ArchUnitNET.Demo.Application.Requirements.Commands.UpdateCompliedState;
using ArchUnitNET.Demo.Application.Checklists.Queries.GetChecklists;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddPresentation() // Presentation layer
        .AddAppLayers(); // Application, Domain, and Infrastructure layers
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.MapGet("/api/checklists", async (ISender mediator) =>
    {
        var command = new GetChecklistsQuery();
        var result = await mediator.Send(command);

        return result.Match(
            Results.Ok,
            _ => Results.StatusCode(StatusCodes.Status500InternalServerError));
    })
    .WithName("GetChecklists")
    .WithSummary("Retrieves all checklists from the database.")
    .WithDescription("Retrieves all checklist items from the database.");
    //.Produces<IEnumerable<Checklist>>(StatusCodes.Status200OK)
    //.Produces<IEnumerable<Checklist>>(StatusCodes.Status500InternalServerError);

    app.MapPost("/api/checklists", async (AddChecklistRequest request, ISender mediator, IMapper mapper) =>
    {
        var command = mapper.Map<AddChecklistCommand>(request);
        var result = await mediator.Send(command);

        return result.Match(
            addChecklistCommandResult => Results.Created($"/api/checklists/{addChecklistCommandResult.Id}", addChecklistCommandResult),
            _ => Results.StatusCode(StatusCodes.Status500InternalServerError));
    })
    .WithName("AddChecklist")
    .WithSummary("Adds a new checklist to the database.")
    .WithDescription("Creates a new checklist item with the specified name.");
    //.Produces<Checklist>(StatusCodes.Status201Created);

    app.MapDelete("/api/checklists/{checklistId}", async (string checklistId, ISender mediator) =>
    {
        var command = new DeleteChecklistCommand(Guid.Parse(checklistId));
        var result = await mediator.Send(command);

        return result.Match(
            _ => Results.NoContent(),
            _ => Results.StatusCode(StatusCodes.Status500InternalServerError));
    })
    .WithName("DeleteChecklist")
    .WithSummary("Deletes a checklist from the database.")
    .WithDescription("Deletes a checklist item with the specified ID.")
    .Produces(StatusCodes.Status204NoContent);

    app.MapPost("/api/checklists/{checklistId}/requirements", async (AddRequirementRequest request, string checklistId, ISender mediator, IMapper mapper) =>
    {
        var command = mapper.Map<AddRequirementCommand>(request) with { ChecklistId = Guid.Parse(checklistId) };
        var result = await mediator.Send(command);

        return result.Match(
            addRequirementCommand => Results.Created($"/api/checklists/{checklistId}/requirements/{addRequirementCommand.Id}", addRequirementCommand),
            _ => Results.StatusCode(StatusCodes.Status500InternalServerError));
    })
    .WithName("AddRequirement")
    .WithSummary("Adds a new requirement to a checklist.")
    .WithDescription("Creates a new requirement item for the specified checklist.");
    //.Produces<IEnumerable<Requirement>>(StatusCodes.Status200OK);

    app.MapPost("/api/requirements/{requirementId}/compliance", async (UpdateCompliedStateRequest request, string requirementId, ISender mediator, IMapper mapper) =>
    {
        var command = mapper.Map<UpdateCompliedStateCommand>(request) with { RequirementId = Guid.Parse(requirementId) };
        var result = await mediator.Send(command);

        return result.Match(
            updateCompliedStateResult => Results.Ok(updateCompliedStateResult),
            _ => Results.StatusCode(StatusCodes.Status500InternalServerError));
    })
    .WithName("UpdateCompliedState")
    .WithSummary("Updates the compliance state of a requirement.")
    .WithDescription("Updates the compliance state of a requirement item with the specified ID.");
   //.Produces<IEnumerable<Requirement>>(StatusCodes.Status200OK);

    app.Run();
}


