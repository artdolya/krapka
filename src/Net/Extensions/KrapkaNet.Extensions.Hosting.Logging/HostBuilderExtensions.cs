using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

namespace KrapkaNet.Extensions.Hosting.Logging
{
    /// <summary>
    ///    Extension methods for <see cref="IHostBuilder" />.
    /// </summary>
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddLogging(this IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });
            hostBuilder.ConfigureServices((context, services) => { services.AddLogging(builder => { builder.AddSerilog(dispose: true); }); });

            return hostBuilder;
        }
    }
}