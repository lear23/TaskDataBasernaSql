

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.PlayerRepo;

public class AddressRepo : Repo<AddressEntity>
{
    public AddressRepo(DataContext context) : base(context)
    {
    }
}
