using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

public class UserTestRepository(TestDbContext dbContext) : Repository<User>(dbContext)
{
    public IEnumerable<User> GetActiveUsers()
    {
        return DbSet.Where(x => x.IsActive);
    }
}