

using System.ComponentModel.DataAnnotations;

namespace TextInMemoryDatabase.TextEntities;


public class ContactEntity
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
}
