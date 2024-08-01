# KrapkaNet.Extensions.Hosting.Postgres

This package registers Postgres packages basing on [Npgsql](https://github.com/npgsql/npgsql)

## Getting started

### Prerequisites

Add the following NuGet package to your project:

```shell
dotnet add package KrapkaNet.Extensions.Hosting.Postgres
```

## Configuration

```json
{
  "ConnectionStrings": {
    "myConnectionStringName": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres"
  }
}
```

## Usage

Reference the package in your code:

```csharp
using KrapkaNet.Extensions.Hosting.Postgres;
```

Add PostgresDbContext to your application.

```csharp
services.AddPostgresDbContext("myConnectionStringName");
```

## Feedback

- Create an issue on [GitHub](https://github.com/artdolya/krapka/issues).
