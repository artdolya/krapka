# Service collection extensions for PostgreSQL

## usage

```csharp
    services.AddPostgresDbContext("myConnectionStringName");
```

## Configuration
```json
{
  "ConnectionStrings": {
    "myConnectionStringName": "Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres"
  }
}
```