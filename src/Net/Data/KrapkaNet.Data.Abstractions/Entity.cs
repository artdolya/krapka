namespace KrapkaNet.Data.Abstractions;

public class Entity<TId> : IEntity<TId>
{
    public required TId Id { get; set; }
}

public class Entity : Entity<Guid>
{
}

public class ClassicEntity : Entity<int>
{
}