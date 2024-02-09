

using System.Diagnostics;
using TaskDataBaseSql.ProductsEntities;
using TaskDataBaseSql.ProductsRepo;


namespace TaskDataBaseSql.ProductService;

public class ClientsService
{
    private readonly ClientsRepo _clientRepo;
    private readonly ReaderService _readerService;
    private readonly DirectionService _directionService;

    public ClientsService(ClientsRepo clientRepo, ReaderService readerService, DirectionService directionService)
    {
        _clientRepo = clientRepo;
        _readerService = readerService;
        _directionService = directionService;
    }
    public ClientsEntity CreateClient(string firstName, string lastName, string readerName,string streetName, string postalCode, string city)
    {
        try
        {
            var reader = _readerService.CreateReader(readerName);
            var direction = _directionService.CreateDirection(streetName, postalCode, city);
            

            var clientEntity = new ClientsEntity
            {
                FirstName = firstName,
                LastName = lastName,
                ReaderId = reader.Id,
                DirectionId = direction.Id
            };
            clientEntity = _clientRepo.Create(clientEntity);

            return clientEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateClientService :: " + ex.Message); }
        return null!;
    }



    public ClientsEntity GetClientById(int id)
    {
        try
        {
            var clientEntity = _clientRepo.Get(x => x.Id == id);
            return clientEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdClientService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<ClientsEntity> GetAllClients()
    {
        try
        {
            var clients = _clientRepo.GetAll();
            return clients;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllUsersService :: " + ex.Message); }
        return null!;
    }


    public ClientsEntity UpdateClient(ClientsEntity client)
    {
        try
        {
            var update= _clientRepo.Update(x => x.Id == client.Id, client);
            return update;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateUserService :: " + ex.Message); }
        return null!;
    }

    public void DeleteClient(int id)
    {
        try
        {
            _clientRepo.Delete(x => x.Id == id);

        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteClientService :: " + ex.Message); }

    }


    //public bool DeleteClient(Expression<Func<ClientEntity, bool>> expression)
    //{
    //    try
    //    {
    //        var result = _clientRepo.Delete(expression);
    //        return result;
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteClientService :: " + ex.Message); }
    //    return false;

    //}



}
