using FluentAssertions;
using KrapkaNet.Data.Abstractions;
using KrapkaNet.Repositories.Abstractions;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories
{
    // Simple concrete entity that satisfies IEntity<Guid>
    internal class TestEntity : Entity
    {
    }

    public class RepositoryTypeTests
    {
        [Fact]
        public void Repository_TEntity_Should_Implement_All_Repository_Interfaces()
        {
            var type = typeof(Repository<TestEntity>);

            // High-level repository interfaces
            type.Should().BeAssignableTo<IRepository<TestEntity>>();
            type.Should().BeAssignableTo<IRepository<TestEntity, Guid>>();

            // Reader variants
            type.Should().BeAssignableTo<IRepositoryReader<TestEntity>>();
            type.Should().BeAssignableTo<IRepositoryReader<TestEntity, Guid>>();

            // Writer variant (non-keyed only exists)
            type.Should().BeAssignableTo<IRepositoryWriter<TestEntity>>();

            // Remover variants
            type.Should().BeAssignableTo<IRepositoryRemover<TestEntity>>();
            type.Should().BeAssignableTo<IRepositoryRemover<TestEntity, Guid>>();
        }
    }
}
