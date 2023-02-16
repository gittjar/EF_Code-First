
# Entity Framework (Code First program)

In terminal (project folder) before running program use commands:

dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet ef migrations remove

dotnet ef migrations add FirstMigration

dotnet ef database update

dotnet run

