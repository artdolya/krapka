using KrapkaNet.Data.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.Data.EntityFramework.Tests
{
    public class TestDbContext(DbContextOptions options) : ApplicationDbContext(options)
    {
        DbSet<User> Users { get; set; }
    }

    public class User : Entity<int>
    {
    }
}