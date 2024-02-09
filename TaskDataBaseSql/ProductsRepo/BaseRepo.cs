

using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Contexts;

namespace TaskDataBaseSql.ProductsRepo;

public class BaseRepo<TEntity> where TEntity : class
{
    private readonly ProductDataContext _productData;

    public BaseRepo(ProductDataContext productData)
    {
        _productData = productData;
    }



    public virtual TEntity Create(TEntity entity)
    {
        try
        {
            _productData.Set<TEntity>().Add(entity);
            _productData.SaveChanges();
            return entity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }

    public virtual TEntity Get(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var entity = _productData.Set<TEntity>().FirstOrDefault(expression);
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
            var entity = _productData.Set<TEntity>().ToList();
            if (entity != null)
            {
                return entity;
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }
    //public virtual IEnumerable<TEntity> GetAll()
    //{
    //    try
    //    {
    //        return _productData.Set<TEntity>().ToList();

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
    //    return null!;
    //}


    public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    {
        try
        {
            _productData.Set<TEntity>().Update(entity);
            _productData.SaveChanges();
            return entity!;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
        return null!;
    }


    //två parammeter i  var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression, entity);?????

    //public virtual TEntity Update(Expression<Func<TEntity, bool>> expression, TEntity entity)
    //{
    //    try
    //    {
    //        var entityUpdate = _context.Set<TEntity>().FirstOrDefault(expression);
    //        _productData.Entry(entityUpdate!).CurrentValues.SetValues(entity);
    //        _productData.SaveChanges();
    //        return entity!;
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR CreateRepo :: " + ex.Message); }
    //    return null!;
    //}

    public virtual bool Delete(Expression<Func<TEntity, bool>> expression)
    {
        try
        {
            var result = _productData.Set<TEntity>().FirstOrDefault(expression);
            if (result != null)
            {
                _productData.Set<TEntity>().Remove(result);
                _productData.SaveChanges();
                return _productData.Set<TEntity>().Any(expression);
            }
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteRepo :: " + ex.Message); }
        return false;


    }

}