using KrapkaNet.Repositories.EntityFramework.Tests.Data;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Extentions;

public static class SeedTestData
{
    public static async Task Seed(this TestDbContext dbContext)
    {
        var user = new User
        {
            Id = new Guid("00000000-0000-0000-0000-000000000001"),
            Username = "firstUser",
            Password = "password1",
            Email = "user1@example.com",
            Books = new List<Book>(),
            IsActive = true
        };
        user.Books.Add(new Book(){
            Id = 1,
            Name = "Book1",
            Description = "Book1 description",  
            Price = 10.99m,
            Quantity = 10,
            Author = user 
        });
        await dbContext.Users.AddAsync(user);
        await dbContext.SaveChangesAsync();
    }
}