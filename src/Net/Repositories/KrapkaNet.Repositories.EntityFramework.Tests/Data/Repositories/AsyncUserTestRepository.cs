using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

public class AsyncUserTestRepository(TestDbContext dbContext) : AsyncRepository<User, Guid>(dbContext)
{
    public IEnumerable<User> GetActiveUsersAsync()
    {
        return DbSet.Where(x => x.IsActive);
    }
}