

using System.ComponentModel.DataAnnotations;

namespace TextInMemoryDatabase.TextEntities;

public class AddressEntity
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string StreetName { get; set; } = null!;
    public string PostalCode { get; set; } = null!;
    public string City { get; set; } = null!;

}
