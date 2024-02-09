

using System.ComponentModel.DataAnnotations;

namespace TaskDataBaseSql.Entities;

public class ClientEntity
{
    [Key]
    public int Id { get; set; }


    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public int AddressId { get; set; } 
    public AddressEntity Address { get; set; } = null!;

    public int ContactId { get; set; }
    public ContactEntity Contact { get; set; } = null!;
}
