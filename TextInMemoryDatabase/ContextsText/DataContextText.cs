

using Microsoft.EntityFrameworkCore;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.ContextsText;

public class DataContextText : DbContext
{
    public DataContextText()
    {
        
    }

    public DataContextText(DbContextOptions options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase($"{Guid.NewGuid()}");
    }

    public DbSet<AddressEntity> Address { get; set; }
    public DbSet<ContactEntity> Contact { get; set; }
    public DbSet<RoleEntity> Role { get; set; }
    public DbSet<ClientEntity> Client { get; set; }
    public DbSet<UserEntity> User { get; set; }




}
