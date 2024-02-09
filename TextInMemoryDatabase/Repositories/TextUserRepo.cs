

using System.Diagnostics;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.Repositories;

public class TextUserRepo
{
    private readonly DataContextText _dataContext;

    public TextUserRepo(DataContextText dataContext)
    {
        _dataContext = dataContext;
    }

    public UserEntity Create(UserEntity entity)
    {
        try
        {
            
            _dataContext.User.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
    public virtual IEnumerable<UserEntity> GetAll()
    {
        try
        {
            return _dataContext.User.ToList();

        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
}
