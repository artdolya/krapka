using KrapkaNet.Repositories.EntityFramework.Tests.Data.Entities;

namespace KrapkaNet.Repositories.EntityFramework.Tests.Data.Models;

public class UserModel
{
    public Guid Id { get; set; }
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public IList<BookModel> Books { get; set; } = null!;
}