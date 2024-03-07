using FluentAssertions;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Models;
using KrapkaNet.Repositories.EntityFramework.Tests.Data.Repositories;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories;

public class AsyncRepositoryReadTests : EntityFrameworkBaseTest
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
        var testRepository = new AsyncUserTestRepository(dbContext);    

        // Act
        var result = await testRepository.GetByAsync(user.Id);
        
        // Assert
        result.Should().NotBeNull();
    }
    
    [Fact]
    public async Task UserRepository_GetBy_Id_Return_Null()
    {
        // Arrange
        var dbContext = CreateDbContext();
        var testUserRepository = new AsyncUserTestRepository(dbContext);    

        // Act
        var user = await testUserRepository.GetByAsync(new Guid("10000000-0000-0000-0000-000000000000"));
        
        // Assert
        user.Should().BeNull();
    }
    
    [Fact]
    public async Task UserRepository_GetBy_Username_Return_User()
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
        var testUserRepository = new AsyncUserTestRepository(dbContext);

        // Act
        var result = await testUserRepository.GetByAsync(u => u.Username == user.Username);
        
        // Assert
        result.Should().NotBeNull();
    }
}