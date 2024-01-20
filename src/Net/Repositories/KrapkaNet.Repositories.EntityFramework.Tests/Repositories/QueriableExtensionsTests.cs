using FluentAssertions;
using KrapkaNet.Repositories.EntityFramework.Extensions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Models;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class QueryableExtensionsTests : EntityFrameworkBaseTest
{
    [Fact]
    public void QueryableExtensions_Map_Should_Return_Model()
    {
        // Arrange
        var dbContext = CreateDbContext();
        dbContext.Users.Add(new User
        {
            Username = $"test-{Guid.NewGuid()}",
            Password = "password",
            Email = "email"
        });
        dbContext.SaveChanges();
        
        // Act
        var result = dbContext.Users.Map<User, UserModel>(u => new UserModel
        {
            // Id = u.Id,
            // Username = u.Username,
            // Email = u.Email
            Books = u.Books.Select(uc => new BookModel() { Id = uc.Id, Title = uc.Name }).ToList()
        }).First();
        
        // Assert
        result.Should().NotBeNull();
        result.Books.Should().NotBeNull();
        result.Books.Should().BeEmpty();
        result.Should().BeOfType<UserModel>();
    }
}