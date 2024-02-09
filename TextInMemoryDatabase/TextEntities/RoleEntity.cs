

using System.ComponentModel.DataAnnotations;

namespace TextInMemoryDatabase.TextEntities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;

}
