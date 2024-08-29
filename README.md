
# ArchTests.Demo 🏪
This solution is a demo project built on the philosophy of Clean Architecture, incorporating DDD and CQRS patterns. It features a simple API with a minimal set of functions for managing Checklist and Requirement entities, where Requirements belong to Checklists. Essentially, it’s a familiar to-do list with a different label. To keep things straightforward, in-memory repositories are used, so the data only persists for the duration of the API's runtime.

## Motivation

### **Showcasing the beauty of architectural testing and how it harmonizes with DDD and CQRS, ensuring a powerful and continuous alignment with design principles.**

## Stack

**Arch:** Clean Architecture, DDD, CQRS
**Tech:** .NET 8 Minimal Api, MediatR, Mapster, ErrorOr, FluentValidation, xUnit, ArchUnitNET


## Run It 🏃
It has no external dependencies. To run the project, simply execute:

`otnet run --project "src/ArchUnitNET.Demo.Api"`

## Explore It 🔎

Swagger is integrated, allowing you to explore all endpoints at `<api_root_url>/swagger`.

![enter image description here](https://i.postimg.cc/CM88d4t3/swagger-demo.png)

### Endpoints

##### Checklists:
Add : `POST:{{host}}/api/checklists`
Get All : `GET:{{host}}/api/checklists`
Delete : `DELETE:{{host}}/api/checklists/{{checklistId}}`
##### Requirements:
Add To Checklist : `POST:{{host}}/api/checklists/{{checklistId}}/requirements`
Update <u>IsComplied</u> Flag : `PATCH:{{host}}/api/requirements/{{requirementId}}`

## Play With It 🎮
The `requests` folder contains examples of all the requests supported by the API. You can try them out directly from VS Code, as shown below.

![enter image description here](https://i.postimg.cc/5NDVXDvd/2024-08-29-17-11-19.gif)

Ensure you have the [REST Client](https://marketplace.visualstudio.com/items?itemName=humao.rest-client) extension installed in VS Code and set the `dev` environment (`Ctrl+Alt+E`  or `Cmd+Alt+E` for macOS).

## Test It 🧪

This implementation includes only architectural tests. To run them, execute: `dotnet test`.
