using FluentAssertions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class RepositoryReadTests : EntityFrameworkBaseTest
{

    [Fact]
    public async Task UserRepository_GetBy_Id_Return_User()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var user = new User
        {
            Username = $"test-{Guid.NewGuid()}",
            Password = "password",
            Email = "email"
        };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        var testRepository = new UserTestRepository(dbContext);    

        // Act
        var result = testRepository.GetBy(user.Id);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task UserRepository_GetByAsync_Id_Return_User()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var user = new User
        {
            Username = $"test-{Guid.NewGuid()}",
            Password = "password",
            Email = "email"
        };
        dbContext.Users.Add(user);
        await dbContext.SaveChangesAsync();
        var testRepository = new UserTestRepository(dbContext);    

        // Act
        var result = await testRepository.GetByAsync(user.Id);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public void UserRepository_GetBy_Id_Return_Null()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var testUserRepository = new UserTestRepository(dbContext);    

        // Act
        var user = testUserRepository.GetBy(new Guid("10000000-0000-0000-0000-000000000000"));
        
        // Assert
        user.Should().BeNull();
    }
    
    [Fact]
    public void UserRepository_GetBy_Username_Return_User()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var user = new User
        {
            Username = $"test-{Guid.NewGuid()}",
            Password = "password",
            Email = "email"
        };
        dbContext.Users.Add(user);
        dbContext.SaveChanges();
        var testUserRepository = new UserTestRepository(dbContext);

        // Act
        var result = testUserRepository.GetBy(u => u.Username == user.Username);
        
        // Assert
        result.Should().NotBeNull();
    }
}