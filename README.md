# PayRoll

ASP.NET-based payroll system with:
- Backend APIs in `FleetProject` (Web API)
- Frontend in `FleetProjectUI` (MVC/UI)

## Repository

- Remote: `https://github.com/K1NG2I/PayRoll.git`
- Default branch: `main`

This local folder is connected to GitHub via `origin`.

## Project Structure

- `FleetProject/RFQ.sln` - main backend solution
- `FleetProject/RFQ.Web.Api` - API project
- `FleetProjectUI/RFQ.UI/RFQ.UI.sln` - frontend/UI solution
- `FleetProjectUI/RFQ.UI` - MVC/UI project

## Prerequisites

- .NET SDK 8.0 or later
- SQL Server (or compatible connection target used by the appsettings)

## Local Setup

1. Clone and enter repo:
   ```bash
   git clone https://github.com/K1NG2I/PayRoll.git
   cd PayRoll
   ```

2. Restore backend dependencies:
   ```bash
   dotnet restore FleetProject/RFQ.sln
   ```

3. Restore frontend dependencies:
   ```bash
   dotnet restore FleetProjectUI/RFQ.UI/RFQ.UI.sln
   ```

4. Update configuration values as needed (connection strings, secrets, service URLs) in:
   - `FleetProject/RFQ.Web.Api/appsettings.json`
   - `FleetProject/RFQ.Web.Api/appsettings.Development.json` (if present)
   - `FleetProjectUI/RFQ.UI/appsettings.json` (if present)

## Run Locally

### Start Backend API

```bash
dotnet run --project FleetProject/RFQ.Web.Api/RFQ.Web.Api.csproj
```

### Start Frontend MVC/UI

```bash
dotnet run --project FleetProjectUI/RFQ.UI/RFQ.UI.csproj
```

Run each command in a separate terminal session.

## Build

```bash
dotnet build FleetProject/RFQ.sln
dotnet build FleetProjectUI/RFQ.UI/RFQ.UI.sln
```

## Git Workflow

Common commands:

```bash
git status
git add .
git commit -m "your message"
git push origin main
```

## Notes

- There is an additional legacy/alternate UI path under `FleetProjectUI/RFQUI-Amit-Transactions-13-01-2026`.
- Use the `RFQ.UI` solution as the primary frontend unless you explicitly need the alternate folder.
