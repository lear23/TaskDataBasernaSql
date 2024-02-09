

using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.PlayerRepo;

public class ClientRepo : Repo<ClientEntity>
{
    private readonly DataContext _context;

    public ClientRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override ClientEntity Get(Expression<Func<ClientEntity, bool>> expression)
    {
        var entity = _context.Clients
            .Include(i => i.Address)
            .Include(i => i.Contact)
            .FirstOrDefault(expression);
        return entity!;
    }

    public override IEnumerable<ClientEntity> GetAll()
    {
        var entity = _context.Clients
            .Include(i => i.Address)
            .Include(i => i.Contact)
            .ToList();
        return entity;
    }
}
