# ApplicationDBContext

Basing on IEntity registers Id as a Primary Key for the for Entities. 
Also changed naming of tables according to singular form of the entity name.

## Usage

```csharp
public class SomeIdentityDbContext(DbContextOptions options) : ApplicationDbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreating<SomeIdentityDbContext>(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(b => b.UserName)
            .IsUnique();
        
        //...
    }
}
```

