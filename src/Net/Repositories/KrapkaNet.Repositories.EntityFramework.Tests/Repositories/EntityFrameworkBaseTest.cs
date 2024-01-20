using KrapkaNet.Repositories.EntityFramework.Tests.Data;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class EntityFrameworkBaseTest
{
    protected TestDbContext CreateDbContext()
    {
        var builder = new DbContextOptionsBuilder<TestDbContext>().UseInMemoryDatabase($"TestReadDb-{Guid.NewGuid()}");
        return new TestDbContext(builder.Options);
    }
}