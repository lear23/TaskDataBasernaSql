﻿

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskDataBaseSql.Entities;

public class UserEntity
{
    [Key]
    public int Id { get; set; }

    public string PlayerName { get; set; } = null!;

    public string Status { get; set; } = null!;
   
    public int RoleId { get; set; } 

    public RoleEntity Role { get; set; } = null!;


}
