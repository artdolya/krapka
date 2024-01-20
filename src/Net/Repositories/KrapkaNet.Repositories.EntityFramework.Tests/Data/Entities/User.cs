using KrapkaNet.Data.Abstractions;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

public class User: Entity, ICloneable
{
    public required string Username { get; set; }
    public required string Password { get; set; }
    public required string Email { get; set; }
    public ICollection<Book>? Books { get; set; }
    public bool IsActive { get; set; }
    
    public object Clone()
    {
        return new User
        {
            Id = Id,
            Username = Username,
            Password = Password,
            Email = Email,
            IsActive = IsActive
        };
    }
}