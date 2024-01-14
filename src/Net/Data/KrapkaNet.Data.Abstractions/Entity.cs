using System;

namespace KrapkaNet.Data.Abstractions
{
    public abstract class Entity<TId> : IEntity<TId> where TId : struct
    {
        public TId Id { get; set; }
    }

    public class Entity : Entity<Guid>
    {
    }

    public class ClassicEntity : Entity<int>
    {
    }
}