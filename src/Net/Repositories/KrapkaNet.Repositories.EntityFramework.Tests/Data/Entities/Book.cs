using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

public class Book : Entity<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public User Author { get; set; }
}