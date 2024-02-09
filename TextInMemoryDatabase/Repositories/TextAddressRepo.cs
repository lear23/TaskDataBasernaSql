

using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using TextInMemoryDatabase.ContextsText;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.Repositories;

public class TextAddressRepo
{
    private readonly DataContextText _dataContext;

    public TextAddressRepo(DataContextText dataContext)
    {
        _dataContext = dataContext;
    }

    public AddressEntity Create(AddressEntity entity)
    {
        try
        {
            _dataContext.Address.Add(entity);
            _dataContext.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<AddressEntity> GetAll()
    {
        try
        {
           return _dataContext.Address.ToList();
            
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }



}
