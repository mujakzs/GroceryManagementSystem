# Grocery Management System

Overview
- Multi-project .NET 9 solution providing a Grocery Management System.
- Includes a Blazor-based Web UI (`GrocerySys.WebUi`), a Web API (`GrocerySys.API`), core Application, Domain and Infrastructure projects.
- UI uses MudBlazor for components.

Prerequisites
- .NET 9 SDK
- (Optional) Visual Studio 2022/2026 or VS Code
- SQL Server (or change provider in `GrocerySys.Infrastructure`)

Quick start (CLI)
1. Restore and build
   - `dotnet restore`
   - `dotnet build`
2. Run Web UI
   - `dotnet run --project GrocerySys.WebUi`
3. Run API
   - `dotnet run --project GrocerySys.API`

If using Visual Studio
- Open the solution and use __Build > Build Solution__.
- Set `GrocerySys.WebUi` (or `GrocerySys.API`) as the startup project.

Project list, Target Frameworks
- `GrocerySys.WebUi` — Target: `net9.0` — Blazor Web UI (uses MudBlazor)
- `GrocerySys.API` — Target: `net9.0` — ASP.NET Core Web API
- `GrocerySys.Application` — Target: `net9.0` — Application layer (business logic)
- `GrocerySys.Infrastructure` — Target: `net9.0` — Persistence, EF Core setup
- `GrocerySys.Domain` — Target: `net9.0` — Domain models and value objects

Project references
- `GrocerySys.WebUi`
  - ProjectReference: `..\GrocerySys.Application\GrocerySys.Application.csproj`
- `GrocerySys.API`
  - ProjectReference: `..\GrocerySys.Application\GrocerySys.Application.csproj`
- `GrocerySys.Application`
  - ProjectReference: `..\GrocerySys.Domain\GrocerySys.Domain.csproj`
- `GrocerySys.Infrastructure`
  - ProjectReference: `..\GrocerySys.Application\GrocerySys.Application.csproj`
  - ProjectReference: `..\GrocerySys.Domain\GrocerySys.Domain.csproj`

Package dependencies (from each project)
- `GrocerySys.WebUi`
  - `Microsoft.Extensions.DependencyInjection` (9.0.10)
  - `MudBlazor` (8.*)
- `GrocerySys.API`
  - `Microsoft.AspNetCore.Authentication.JwtBearer` (9.0.10)
  - `Microsoft.AspNetCore.Mvc.NewtonsoftJson` (9.0.10)
  - `Microsoft.AspNetCore.OpenApi` (9.0.9)
  - `Microsoft.Extensions.DependencyInjection` (9.0.10)
- `GrocerySys.Application`
  - `MediatR` (13.1.0)
- `GrocerySys.Infrastructure`
  - `Microsoft.EntityFrameworkCore.SqlServer` (9.0.10)
  - `Microsoft.EntityFrameworkCore.Tools` (9.0.10) — PrivateAssets=all
  - `Microsoft.Extensions.Configuration` (9.0.10)
- `GrocerySys.Domain`
  - `System.Text.Json` (9.0.10)

Database / EF Core
- The project includes `Microsoft.EntityFrameworkCore.SqlServer` and EF Tools in `GrocerySys.Infrastructure`.
- Typical commands:
  - Add migration:
    - `dotnet ef migrations add Initial -p GrocerySys.Infrastructure -s GrocerySys.API`
  - Apply migrations:
    - `dotnet ef database update -p GrocerySys.Infrastructure -s GrocerySys.API`
- Ensure `GrocerySys.API` (or chosen startup project) contains the correct connection string configuration.

Notes & recommendations
- The Web UI uses MudBlazor — consult MudBlazor docs for theming and components.
- `MediatR` is used in the Application layer for request/notification patterns.
- Keep `GrocerySys.Domain` free of infrastructure dependencies.
- If running both UI and API locally, ensure they use different ports or are hosted together as required.

Repository info
- Local clone path (example): `C:\Users\MIS\source\repos\GroceryManagementSystem`
- Branch: `master`
- Remote origin: `https://github.com/mujakzs/GroceryManagementSystem`
