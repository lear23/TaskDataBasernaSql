

using System.ComponentModel.DataAnnotations;

namespace TextInMemoryDatabase.TextEntities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    public string PlayerName { get; set; } = null!;

    public string Status { get; set; } = null!;

    public int RoleId { get; set; } 

    public RoleEntity Role { get; set; } = null!;
}
