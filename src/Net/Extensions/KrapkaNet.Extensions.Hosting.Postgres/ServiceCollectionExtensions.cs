using KrapkaNet.EntityFramework.Abstractions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KrapkaNet.Extensions.Hosting.Postgres
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddPostgresDbContext<TContext>(this IServiceCollection services, string connectionString)
            where TContext : ApplicationDbContext
        {
            services.AddDbContext<TContext>((serviceProvider, dbContextOptionsBuilder) =>
            {
                dbContextOptionsBuilder.UseNpgsql(
                    serviceProvider.GetRequiredService<IConfiguration>().GetConnectionString(connectionString),
                    npgsqlOptionsBuilder =>
                        npgsqlOptionsBuilder.MigrationsAssembly(typeof(TContext).Assembly.FullName));
            });
        
            return services;
        }
    }
}