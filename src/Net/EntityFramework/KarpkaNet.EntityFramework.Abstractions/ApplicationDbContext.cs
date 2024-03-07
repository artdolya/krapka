using System.Linq;
using KrapkaNet.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KarpkaNet.EntityFramework.Abstractions
{
    public abstract class ApplicationDbContext : DbContext
    {
        protected ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected void OnModelCreating<T>(ModelBuilder modelBuilder)
        {
            var types = typeof(T).Assembly.GetTypes()
                .Where(t => t is { IsClass: true, IsAbstract: false, IsNested: false })
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntity<>)))
                .ToList();
        
            foreach (var type in types)
            {
                modelBuilder.Entity(type).ToTable(type.Name).HasKey(nameof(IEntity<int>.Id)) ;
            }
        
            base.OnModelCreating(modelBuilder);
        }
    }
}