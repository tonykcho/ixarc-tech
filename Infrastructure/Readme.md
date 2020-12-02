# Migrations

## IdentityServerAPI

> Add Migrations

	dotnet ef migrations add $name --startup-project ..\IdentityServerAPI\IdentityServerAPI.csproj -o .\Migrations

> Remove Migrations

	dotnet ef migrations remove --startup-project ..\IdentityServerAPI\IdentityServerAPI.csproj