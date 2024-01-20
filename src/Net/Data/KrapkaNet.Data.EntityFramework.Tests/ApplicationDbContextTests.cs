using FluentAssertions;
using KrapkaNet.Data.EntityFramework;
using KrapkaNet.Data.EntityFramework.Tests;
using Microsoft.EntityFrameworkCore;

namespace KrapkaNet.DaTA.EntityFramework.Tests;

public class ApplicationDbContextTests
{
    private readonly DbContextOptionsBuilder<ApplicationDbContext> _builder =
        new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase($"TestDb-{Guid.NewGuid()}");

    [Fact]
    public void TestDbContext_Should_Use_Singular_TableName_For_UserEntity()
    {
        // Arrange
        var dbContext = new TestDbContext(_builder.Options);

        // Act
        var entities = dbContext.Model.GetEntityTypes();
        var userEntity = entities.FirstOrDefault(t => t.Name == typeof(User).FullName);
        var tableName = userEntity?.GetTableName();
        // Assert 
        userEntity.Should().NotBeNull();
        tableName.Should().BeEquivalentTo(nameof(User));
    }
}