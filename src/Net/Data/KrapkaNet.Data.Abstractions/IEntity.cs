﻿namespace KrapkaNet.Data.Abstractions
{
    public interface IEntity
    {
    }

    public interface IEntity<TKey> : IEntity where TKey : struct
    {
        TKey Id { get; set; }
    }
}