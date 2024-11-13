# Asp.net core And Mapster

This is a simple ASP.NET Core Web API project demonstrating the use of **Mapster** for object mapping and **EF Core with SQLite** for database operations. The project includes a configuration for Mapster, similar to AutoMapper’s `ProjectTo`, allowing efficient query projection.

## Features
- ASP.NET Core Web API
- EF Core with SQLite database
- Mapster for object mapping
- Centralized mapping configuration using `RegisterMapsterConfiguration()`
- `ProjectToType` for efficient query projection (similar to AutoMapper’s `ProjectTo`)
- Basic CRUD operations

## Prerequisites
- .NET 6 or higher
- SQLite

## Getting Started

### 1. Clone the Repository
```bash
git clone https://github.com/yourusername/AspNetCoreAndMapster.git
cd AspNetCoreAndMapster
```
### 2. Install Dependencies
Make sure you have the necessary NuGet packages installed:

- dotnet add package Microsoft.EntityFrameworkCore.Sqlite
- dotnet add package Mapster
- dotnet add package Mapster.DependencyInjection
- dotnet add package Mapster.EntityFrameworkCore

###  3. Database Setup
Initialize the SQLite database and apply migrations:

```bash
Copy code
- dotnet ef migrations add InitialCreate
- dotnet ef database update
