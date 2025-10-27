using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Repositories
{
    // Simple concrete entity that satisfies IEntity<Guid>
    internal class ClassicTestEntity : ClassicEntity
    {
    }

    //public class ClassicRepositoryTypeTests
    //{
    //    [Fact]
    //    public void ClassicRepository_TEntity_Should_Implement_All_Repository_Interfaces()
    //    {
    //        var type = typeof(ClassicRepository<ClassicTestEntity>);

    //        // High-level repository interfaces
    //        type.Should().BeAssignableTo<IClassicRepository<ClassicTestEntity>>();
    //        type.Should().BeAssignableTo<IRepository<ClassicTestEntity, int>>();

    //        // Reader variants
    //        type.Should().BeAssignableTo<IClassicRepositoryReader<ClassicTestEntity>>();
    //        type.Should().BeAssignableTo<IRepositoryReader<ClassicTestEntity, int>>();

    //        // Writer variant (non-keyed only exists)
    //        type.Should().BeAssignableTo<IRepositoryWriter<ClassicTestEntity>>();
    //        // Remover variants
    //        type.Should().BeAssignableTo<IClassicRepositoryRemover<ClassicTestEntity>>();
    //        type.Should().BeAssignableTo<IRepositoryRemover<ClassicTestEntity, int>>();
    //    }
    //}
}
