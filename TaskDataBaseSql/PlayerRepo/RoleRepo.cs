

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.PlayerRepo;

public class RoleRepo : Repo<RoleEntity>
{
    public RoleRepo(DataContext context) : base(context)
    {
    }
}
