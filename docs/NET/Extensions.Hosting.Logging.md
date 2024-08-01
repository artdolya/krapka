# KrapkaNet.Extensions.Hosting.Logging

This package registers logging packages basing on [Serilog](https://github.com/serilog/serilog) library and the JSON configuration file.

## Getting started

### Prerequisites

Add the following NuGet package to your project:

```shell
dotnet add package KrapkaNet.Extensions.Hosting.Logging
```

### Configuration

Configure _appsetting.json_

```json
{
  "Serilog": {
    "Using": ["Serilog.Sinks.Console"],
    "MinimumLevel": {
      "Default": "Information",
      "Override": {
        "System": "Warning",
        "Microsoft": "Warning"
      }
    },
    "Enrich": [
      "FromLogContext",
      "WithThreadId",
      "WithProcessId",
      "WithMachineName"
    ],
    "WriteTo": [
      {
        "Name": "Console",
        "Args": {
          "formatter": "Serilog.Formatting.Compact.CompactJsonFormatter, Serilog.Formatting.Compact"
        }
      }
    ],
    "Properties": {
      "ApplicationName": "My Application Name"
    }
  }
}
```

## Usage

Reference the package in your code:

```csharp
using KrapkaNet.Extensions.Hosting Logging;
```

Use AddLogging to add logs to your application.

### Console application

```csharp
var hostBuilder = Host.CreateDefaultBuilder(args)
                      .AddLogging();
// Your code here
```

### Web application

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Host.AddLogging();
// Your code here
```

## Feedback

- Create an issue on [GitHub](https://github.com/artdolya/krapka/issues).
