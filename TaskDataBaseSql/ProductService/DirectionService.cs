

using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.PortableExecutable;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;
using TaskDataBaseSql.ProductsEntities;
using TaskDataBaseSql.ProductsRepo;

namespace TaskDataBaseSql.ProductService;

public class DirectionService
{
    private readonly DirectionRepo _directionRepo;

    public DirectionService(DirectionRepo directionRepo)
    {
        _directionRepo = directionRepo;
    }

    public DirectionsEntity CreateDirection(string streetName, string postalCode , string city)
    {
        try
        {
            var result = _directionRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            if (result == null)
            {
                result = _directionRepo.Create(new DirectionsEntity { StreetName = streetName, PostalCode = postalCode, City = city });
            }
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateDirectionService :: " + ex.Message); }
        return null!;
    }
     public DirectionsEntity GetDirectionByName(string streetName, string postalCode, string city)
    {
        try
        {
            var result = _directionRepo.Get(x => x.StreetName == streetName && x.PostalCode == postalCode && x.City == city);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateDirectionService :: " + ex.Message); }
        return null!;
    }
    public DirectionsEntity GetDirectionById(int id)
    {
        try
        {
            var result = _directionRepo.Get(x => x.Id == id);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdDirectionService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<DirectionsEntity> GetAllDirections()
    {
        try
        {
            var result = _directionRepo.GetAll();
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllDirectionService :: " + ex.Message); }
        return null!;
    }


    public DirectionsEntity UpdateDirection(DirectionsEntity directionEntity)
    {
        try
        {
            var updateEntity = _directionRepo.Update(x => x.Id == directionEntity.Id, directionEntity);
            return updateEntity;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateDirectionService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteDirection(int id)
    //{
    //    try
    //    {
    //        _directionRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteDirectionService :: " + ex.Message); }

    //}


    public bool DeleteRole(Expression<Func<DirectionsEntity, bool>> expression)
    {
        try
        {
            var result = _directionRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeletedirectionService :: " + ex.Message); }
        return false;

    }




}
