

using System.Diagnostics;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.Repositories;

public class TextRoleRepo
{
    private readonly DataContextText _dataContext;

    public TextRoleRepo(DataContextText dataContext)
    {
        _dataContext = dataContext;
    }

    public RoleEntity Create(RoleEntity entity)
    {
        try
        {
            _dataContext.Role.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<RoleEntity> GetAll()
    {
        try
        {
            return _dataContext.Role.ToList();

        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
}
