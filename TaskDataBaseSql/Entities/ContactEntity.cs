

using System.ComponentModel.DataAnnotations;

namespace TaskDataBaseSql.Entities;

public class ContactEntity
{
    [Key]
    public int Id { get; set; }

    public string Email { get; set; } = null!;

    public string? PhoneNumber { get; set; } = null!;
}
