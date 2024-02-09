

using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.PlayerRepo;

public class ContactRepo : Repo<ContactEntity>
{
    public ContactRepo(DataContext context) : base(context)
    {
    }
}
