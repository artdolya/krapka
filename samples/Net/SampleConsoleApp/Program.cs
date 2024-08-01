// See https://aka.ms/new-console-template for more information
using KrapkaNet.Extensions.Hosting.Logging;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

var hostBuilder = Host.CreateDefaultBuilder(args);
hostBuilder.AddLogging().ConfigureAppConfiguration(builder =>
                                                   {
                                                       string envName =
                                                           Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

                                                       builder.SetBasePath(Directory.GetCurrentDirectory())
                                                              .AddJsonFile("appsettings.json")
                                                              .AddJsonFile($"appsettings.{envName}.json", true)
                                                              .AddEnvironmentVariables();
                                                   });
var host = hostBuilder.Build();
ILogger<Program> logger = host.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Hello, world!");

host.Run();