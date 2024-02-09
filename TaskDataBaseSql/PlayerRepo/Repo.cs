

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Contexts;

namespace TaskDataBaseSql.PlayerRepo;

public class Repo<TEntity> where TEntity : class
{
    private readonly DataContext _context;

    public Repo(DataContext context)
    {
        _context = context;
    }

    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>>expression)
    {
        try
        {
           var entity = _context.Set<TEntity>().FirstOrDefault(expression);
            if (entity != null)
            {
                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual IEnumerable<TEntity> GetAll()
    {
        try
        {
            var entity = _context.Set<TEntity>().ToList();
            if (entity != null)
            {
                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
   

    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
            return entity!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var result = _context.Set<TEntity>().FirstOrDefault(expression);
            if (result != null)
            {
                _context.Set<TEntity>().Remove(result);
                _context.SaveChanges();
                return _context.Set<TEntity>().Any(expression);
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteRepo :: " + ex.Message); }
        return false;
    }

}




//två parammeter i  var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression, entity);?????

//public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
//{
//    try
//    {
//        var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
//        _context.Entry(entityUpdate!).CurrentValues.SetValues(entity);
//        _context.SaveChanges();
//        return entity!;
//    }
//    catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
//    return null!;
//}



//public virtual void Delete(Expression<Func<TEntity, bool>> expression)
//{
//    try
//    {
//        var result = _context.Set<TEntity>().FirstOrDefault(expression);
//            _context.Remove(result!);
//            _context.SaveChanges();


//    }
//    catch (Exception ex) { Debug.WriteLine("ERROR DeleteRepo :: " + ex.Message); }

//}
//public virtual IEnumerable<TEntity> GetAll()
//{
//    try
//    {
//        return _context.Set<TEntity>().ToList();

//    }
//    catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
//    return null!;
//}
