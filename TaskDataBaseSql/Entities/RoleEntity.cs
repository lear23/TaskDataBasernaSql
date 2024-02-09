
using System.ComponentModel.DataAnnotations;

namespace TaskDataBaseSql.Entities;

public class RoleEntity
{
    [Key]
    public int Id { get; set; }
    public string RoleName { get; set; } = null!;


}

