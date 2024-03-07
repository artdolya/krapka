using KrapkaNet.Data.Abstractions;
using KrapkaNet.EntityFramework.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.EntityFramework.Abstraction.Tests
{
    public class TestDbContext(DbContextOptions options) : ApplicationDbContext(options)
    {
        DbSet<User> Users { get; set; }
    }

    public class User : Entity<int>
    {
    }
}