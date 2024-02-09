

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;

namespace TaskDataBaseSql.Services;

public class ClientService
{
    private readonly ClientRepo _clientRepo;
    private readonly AddressService _addressService;
    private readonly ContactService _contactService;

    public ClientService(ClientRepo clientRepo, AddressService addressService, ContactService contactService)
    {
        _clientRepo = clientRepo;
        _addressService = addressService;
        _contactService = contactService;
    }


    public ClientEntity CreateClient(string firstName, string lastName, string streetName, string postalCode, string city, string email, string phoneNumber)
    {
        try
        {
            var addressEntity = _addressService.CreateAddress(streetName, postalCode, city);
            var contact = _contactService.CreateContact(email, phoneNumber);

            var clientEntity = new ClientEntity
            {
                FirstName = firstName,
                LastName = lastName,
                AddressId = addressEntity.Id,
                ContactId = contact.Id
            };
            clientEntity = _clientRepo.Create(clientEntity);

            return clientEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateClientService :: " + ex.Message); }
        return null!;
    }



    public ClientEntity GetClientById(int id)
    {
        try
        {
            var clientEntity = _clientRepo.Get(x => x.Id == id);
            return clientEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdClientService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<ClientEntity> GetAllClients()
    {
        try
        {
            var clients = _clientRepo.GetAll();
            return clients;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllUsersService :: " + ex.Message); }
        return null!;
    }


    public ClientEntity UpdateClient(ClientEntity clientEntity)
    {
        try
        {
            var updateClient = _clientRepo.Update(x => x.Id == clientEntity.Id, clientEntity);
            return updateClient;

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
