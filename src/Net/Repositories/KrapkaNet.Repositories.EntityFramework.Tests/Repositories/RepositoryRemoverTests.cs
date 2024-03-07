using FluentAssertions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class RepositoryRemoverTests : EntityFrameworkBaseTest
{
    [Fact]
    public void UserRepository_Remove_User_By_Entity()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var testUserRepository = new UserTestRepository(dbContext);
        var user = new User
        {
            Username = "test",
            Password = "password",
            Email = "email"
        };

        // Act
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        testUserRepository.Remove(user);
        testUserRepository.Save();
        var result = dbContext.Users.Where(u => u.Username == "test");

        // Assert
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public void UserRepository_Remove_User_By_Id()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var testUserRepository = new UserTestRepository(dbContext);
        var user = new User
        {
            Username = "test",
            Password = "password",
            Email = "email"
        };

        // Act
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        testUserRepository.Remove(user.Id);
        testUserRepository.Save();
        var result = dbContext.Users.Where(u => u.Username == "test");

        // Assert
        result.Count().Should().Be(0);
    }
}