# ArchTests.Demo 🏪
The solution is a demo project built on the philosophy of Clean Architecture, incorporating DDD and CQRS architectural patterns. It features an API with a minimal set of functions for managing Checklist and Requirement entities, where Requirements belong to Checklists. Yes, it's essentially that familiar to-do list everyone knows, just with a different label :) Additionally, to keep things simple, in-memory repositories are used, meaning the data only persists for the duration of the API's runtime. All of this is intended to avoid overcomplicating less critical aspects and focus on the core objective — **Showcasing the Beauty of Architectural Testing and How It Harmonizes With DDD and CQRS, Ensuring a Cohesive and Powerful, Continuous Alignment of Design Principles.**

### Stack

Arch: Clean Architecture, DDD, CQRS
Tech: .NET 8 Minimal Api, MediatR, Mapster, ErrorOr, FluentValidation, xUnit, ArchUnitNET

### Endpoints

POST: {{host}}/api/checklists
GET: {{host}}/api/checklists
DELETE: {{host}}/api/checklists/{{checklistId}}

POST: {{host}}/api/checklists/{{checklistId}}/requirements
POST: {{host}}/api/requirements/{{requirementId}}/compliance

## Run It 🏃
It has no external dependencies. Running it is very straightforward:

`otnet run --project "src/ArchUnitNET.Demo.Api"`

## Explore It 🔎
The project comes with Swagger integration, allowing to explore all the endpoints at: `<api_root_url>/swagger`.

![enter image description here](https://i.postimg.cc/CM88d4t3/swagger-demo.png)

## Play With It 🎮
The `requests` folder contains examples of all the requests supported by the API. You can try them out directly from VS Code, as shown below.
![enter image description here](https://i.postimg.cc/zf4SQhyh/2024-08-24-20-16-20.gif)

A prerequisite for this is having the [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension installed in VS Code and setting the `dev` environment (`Ctrl+Alt+E`  or `Cmd+Alt+E` for macOS) in VS Code.

## Test It 🧪

Basic unit tests covering the main functionality of RestManagerService have been added to the solution. Since this is a demo project, the  <ins>tests are not intended to be comprehensive or fully sufficient</ins>. To run them, simply use the command: `dotnet test`.