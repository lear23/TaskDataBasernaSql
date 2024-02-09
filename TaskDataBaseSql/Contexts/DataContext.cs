

using Microsoft.EntityFrameworkCore;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.Contexts;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }

    public DbSet<AddressEntity> Addresses { get; set; }
    public DbSet<ClientEntity> Clients { get; set; }
    public DbSet<ContactEntity> Contacts { get; set; }    
    public DbSet<RoleEntity> Roles { get; set; }
    public DbSet<UserEntity> Users { get; set; }

}
