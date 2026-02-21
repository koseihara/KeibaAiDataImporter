# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

KeibaAiDataImporter is a .NET 10.0 Windows Forms application that imports Japanese horse racing data (JV-Data) from JRA-VAN into a PostgreSQL database. It features automated entity code generation from JV-Data structure definitions and high-performance bulk import via Npgsql binary COPY.

## Build Commands

```bash
# Build the full solution (requires Visual Studio MSBuild for COM interop)
dotnet build KeibaAiDataImporter.slnx

# Build specific projects
dotnet build KeibaAiDataImporter.Core/KeibaAiDataImporter.Core.csproj
dotnet build KeibaAiDataImporter.Infrastructure/KeibaAiDataImporter.Infrastructure.csproj

# The App project requires x86 platform and JRA-VAN JV-Link installed
dotnet build KeibaAiDataImporter.App/KeibaAiDataImporter.App.csproj -p:Platform=x86
```

**Note:** The App project uses COM interop (JVDTLabLib ActiveX) and requires:
- 32-bit (x86) target platform
- JRA-VAN Data Lab software installed at `C:\Program Files (x86)\JRA-VAN\Data Lab\`
- Visual Studio MSBuild (not .NET Core MSBuild) for COM reference resolution

## Architecture

Three-project solution with clear separation:

### KeibaAiDataImporter.Core (net10.0)
Domain logic and code generation. No external dependencies.
- **Entities/**: `JvEntity` base class + 40+ auto-generated entity classes in `Generated/` (named `{RecordId}Entity`, e.g. `RAEntity`, `H1Entity`)
- **Generators/**: Code generation pipeline that reads `JVData_Struct.cs` and produces C# entity classes, PostgreSQL DDL, and computed column SQL
  - `JvStructParser` → regex-based parser for JV-Data structure definitions
  - `EntityCodeGenerator` → generates entity C# classes
  - `SqlDdlGenerator` → generates CREATE TABLE statements
  - `ComputedColumnGenerator` → generates AI-friendly computed columns
- **Utils/**: `FixedLengthParser` for high-performance Shift-JIS binary record parsing

### KeibaAiDataImporter.Infrastructure (net10.0)
Database access layer. Depends on Core and Npgsql.
- **Database/**: `DbConnectionFactory`, `BulkImporterBase`, `GenericJvImporter` (bulk import with deduplication via temp table merge), `SchemaInitializer`

### KeibaAiDataImporter.App (net10.0-windows, x86)
Windows Forms UI. Depends on Core, Infrastructure, and JV-Link COM.
- `Form1.cs` — main orchestration: DB setup, data spec selection, import loop
- `Controls/TimelinePanel.cs` — custom timeline visualization control
- `JVData_Struct.cs` — JV-Data structure definitions (treated as content, not compiled)

## Data Flow

```
JV-Link ActiveX → JVRead() binary records (Shift-JIS)
  → FixedLengthParser → Entity objects
  → BlockingCollection<JvEntity> (producer-consumer)
  → GenericJvImporter.ImportWithMerge() via Npgsql binary COPY
  → PostgreSQL tables
```

## Code Generation Pipeline

The generators read `JVData_Struct.cs` (135KB, source of truth for record definitions) and produce:
1. Entity classes that flatten nested JV-Data structs into relational properties
2. PostgreSQL DDL with appropriate column types
3. Computed columns for AI workloads (race_id, kaisai_date, etc.)

Record type IDs are 2-character codes: RA (race), H1/H6/HR (horse), O1-O6 (odds), etc.

## Database Configuration

Environment variables (with defaults):
- `DB_HOST` = "localhost"
- `DB_PORT` = "5433"
- `DB_NAME` = "jra_db"
- `DB_USER` = "postgre"
- `DB_PASSWORD` = "password"

## Key Conventions

- Nullable reference types enabled across all projects
- Shift-JIS encoding used for all JV-Data binary parsing (via `System.Text.Encoding.CodePages`)
- Entity property names flatten hierarchical structures with underscores
- `fetch_history.json` persists sync state (last fetch timestamp per data spec)
- Solution uses `.slnx` format (newer XML-based solution format)
