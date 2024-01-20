using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

public class Book: Entity<int>
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required decimal Price { get; set; }
    public required int Quantity { get; set; }
    
    public required User Author { get; set; }
}