

using System.Diagnostics;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.Repositories;


public class TextContactRepo
{
    private readonly DataContextText _dataContext;

    public TextContactRepo(DataContextText dataContext)
    {
        _dataContext = dataContext;
    }

    public ContactEntity Create(ContactEntity entity)
    {
        try
        {
            _dataContext.Contact.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<ContactEntity> GetAll()
    {
        try
        {
            return _dataContext.Contact.ToList();

        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }


}
