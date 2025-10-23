using System;

namespace KrapkaNet.Data.Abstractions
{
    public abstract class Entity<TId> : IEntity<TId> where TId : struct
    {
        public TId Id { get; set; }

        public bool IsNew()
        {
            return Id.Equals(default(TId));
        }
    }

    public abstract class Entity : Entity<Guid>
    {
    }

    public abstract class ClassicEntity : Entity<int>
    {
    }
}