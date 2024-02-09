

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;
using TaskDataBaseSql.ProductsEntities;
using TaskDataBaseSql.ProductsRepo;

namespace TaskDataBaseSql.ProductService;

public class ReaderService
{
    private readonly ReaderRepo _readerRepo;

    public ReaderService(ReaderRepo readerRepo)
    {
        _readerRepo = readerRepo;
    }

    public ReadersEntity CreateReader(string readerName)
    {
        try
        {
            var addressEntity = _readerRepo.Get(x => x.ReaderName == readerName );
            if (addressEntity == null)
            {
                {
                    addressEntity = _readerRepo.Create(new ReadersEntity
                    {
                        ReaderName = readerName,
                       
                    });
                }
            }
            return addressEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRoleService :: " + ex.Message); }
        return null!;
    }
    public ReadersEntity GetRoleByName(string readerName)
    {
        try
        {
            var result = _readerRepo.Get(x => x.ReaderName == readerName );
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetRoleService :: " + ex.Message); }
        return null!;
    }

    public ReadersEntity GetAddressById(int id)
    {
        try
        {
            var result = _readerRepo.Get(x => x.Id == id);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdAddressService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<ReadersEntity> GetAllReaders()
    {
        try
        {
            var reader = _readerRepo.GetAll();
            return reader;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllReaderService :: " + ex.Message); }
        return null!;
    }


    public ReadersEntity UpdateRaeader(ReadersEntity readerEntity)
    {
        try
        {
            var updateReader = _readerRepo.Update(x => x.Id == readerEntity.Id, readerEntity);
            return updateReader;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateReaderService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteReader(int id)
    //{
    //    try
    //    {
    //        _readerRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteReaderService :: " + ex.Message); }

    //}


    public bool DeleteReader(Expression<Func<ReadersEntity, bool>> expression)
    {
        try
        {
            var result = _readerRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteReaderService :: " + ex.Message); }
        return false;

    }





}
