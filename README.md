### Create layers
- dotnet new classlib -n First.Ecard.Domain
- dotnet new classlib -n First.Ecard.Application
- dotnet new classlib -n First.Ecard.Infrastructure
mkdir First.Ecard.Presentation
- cd First.Ecard.Presentation && dotnet new blazor -o First.Ecard.Presentation.UI
- cd First.Ecard.Presentation && dotnet new webapi -n First.Ecard.Presentation.Api

### Add classLib in the solution
- dotnet sln First.Ecard.sln add src/First.Ecard.Domain
- dotnet sln First.Ecard.sln add src/First.Ecard.Application
- dotnet sln First.Ecard.sln add src/First.Ecard.Infrastructure
- dotnet sln First.Ecard.sln add src/First.Ecard.Presentation/First.Ecard.Presentation.Api
- dotnet sln First.Ecard.sln add src/First.Ecard.Presentation/First.Ecard.Presentation.UI

### Add Project References
- dotnet add src/First.Ecard.Application/First.Ecard.Application.csproj reference src/First.Ecard.Domain/First.Ecard.Domain.csproj

- dotnet add src/First.Ecard.Infrastructure/First.Ecard.Infrastructure.csproj reference src/First.Ecard.Domain/First.Ecard.Domain.csproj

- dotnet add src/First.Ecard.Infrastructure/First.Ecard.Infrastructure.csproj reference src/First.Ecard.Application/First.Ecard.Application.csproj

- dotnet add src/First.Ecard.Presentation/First.Ecard.Presentation.Api/First.Ecard.Presentation.Api.csproj reference src/First.Ecard.Application/First.Ecard.Application.csproj

- dotnet add src/First.Ecard.Presentation/First.Ecard.Presentation.Api/First.Ecard.Presentation.Api.csproj reference src/First.Ecard.Infrastructure/First.Ecard.Infrastructure.csproj

### Application Packages
- dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
- dotnet add package MediatR --version 8.0.0
- dotnet add package MediatR.Extensions.Microsoft.DependencyInjection --version 8.0.0
dotnet add package FluentValidation

### Infrastructure Packages
- dotnet add package Microsoft.EntityFrameworkCore --version 8.0.7
- dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.7
- dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.4
- dotnet add package BCrypt.Net-Next
- dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.0
- dotnet add package System.IdentityModel.Tokens.Jwt

### Api Packages
- dotnet add package Microsoft.EntityFrameworkCore.Tools

### 
- dotnet ef migrations add InitialCreate -o Migrations
- dotnet ef database update

### 
- dotnet ef migrations add RenamePasswordField -o Migrations
- dotnet ef migrations add RenamePasswordToPasswordHash -o Migrations
- dotnet ef migrations add addRoleStringConversion -o Migrations
- dotnet ef migrations add setDateOfBithToDateOnly -o Migrations

-- sudo -u postgres psql
--create database first_e_card;
-- \c first_health_care_db;