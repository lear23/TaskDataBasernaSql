

using System.Diagnostics;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.Repositories;

public class TextClientRepo
{
    private readonly DataContextText _dataContext;

    public TextClientRepo(DataContextText dataContext)
    {
        _dataContext = dataContext;
    }

    public ClientEntity Create(ClientEntity entity)
    {
        try
        {
            if (entity.Address == null)
            {
                entity.Address = new AddressEntity();
            }
            if (entity.Contact == null)
            {
                entity.Contact = new ContactEntity();
            }

            _dataContext.Client.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<ClientEntity> GetAll()
    {
        try
        {
            return _dataContext.Client.ToList();

        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
}
