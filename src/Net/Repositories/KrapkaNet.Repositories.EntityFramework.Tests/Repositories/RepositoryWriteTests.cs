using FluentAssertions;
using KrapkaNet.Repositories.Abstractions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class RepositoryWriteTests : EntityFrameworkBaseTest
{
    [Fact]
    public void UserRepository_Add_User()
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
        testUserRepository.AddOrUpdate(user); 
        testUserRepository.Save();  
        var result = dbContext.Users.Where(u => u.Username == "test");
        
        // Assert
        result.Count().Should().Be(1);
        result.Where(u => u.Id == Guid.Empty).Select(u => u.Id).Count().Should().Be(0);
    }

    [Fact]
    public async Task UserRepository_AddAsync_User()
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
        await testUserRepository.AddAsync(user); 
        await testUserRepository.SaveAsync();  
        var result = dbContext.Users.Where(u => u.Username == "test");
        
        // Assert
        result.Count().Should().Be(1);
        result.Where(u => u.Id == Guid.Empty).Select(u => u.Id).Count().Should().Be(0);
    }
    
    [Fact]
    public void UserRepository_Update_User()
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
        user.Username = "test2";
        var result = testUserRepository.AddOrUpdate(user);
        testUserRepository.Save();          
        
        // Assert
        result.Username.Should().Be("test2");
    }
}