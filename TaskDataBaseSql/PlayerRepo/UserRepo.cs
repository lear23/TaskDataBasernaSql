

using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;
using TaskDataBaseSql.Contexts;
using TaskDataBaseSql.Entities;

namespace TaskDataBaseSql.PlayerRepo;

public class UserRepo : Repo<UserEntity>
{
    private readonly DataContext _context;
    public UserRepo(DataContext context) : base(context)
    {
        _context = context;
    }

    public override UserEntity Get(Expression<Func<UserEntity, bool>> expression)
    {
        var entity = _context.Users
            .Include(i => i.Role)
            .FirstOrDefault(expression);
        
            return entity!;
        
    }

    public override IEnumerable<UserEntity> GetAll()
    {
        var entity = _context.Users
            .Include(i => i.Role)
            .ToList();
        return entity;
    }
}
