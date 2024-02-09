

using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextConsoleApp.TextRepositories;

public class MainClient(TextClientRepo textRepo)
{

    private readonly TextClientRepo _textRepo = textRepo;

    public void CreateClient()
    {
        var client = new ClientEntity
        {
            Address = new AddressEntity(),

            Contact = new ContactEntity()
        };

       

        Console.Clear();

        Console.Write("FirstName: ");
        client.FirstName = Console.ReadLine()!;

        Console.Write("LastName :  ");
        client.LastName = Console.ReadLine()!;

        Console.Write("Email : ");
        client.Contact.Email = Console.ReadLine()!;

        Console.Write("PhoneNumber : ");
        client.Contact.PhoneNumber = Console.ReadLine()!;

        Console.Write("StreetName : ");
        client.Address.StreetName = Console.ReadLine()!;

        Console.Write("PostalCode : ");
        client.Address.PostalCode = Console.ReadLine()!;

        Console.Write("City : ");
        client.Address.City = Console.ReadLine()!;


        var entity = _textRepo.Create(client);
        Console.WriteLine($"Address ID : {entity.Id} ");


        Console.ReadKey();

    }

    public void ListAllClient()
    {
        Console.Clear();
        var client = _textRepo.GetAll();
        foreach (var item in client)
        {
            Console.WriteLine($"{item.FirstName} - {item.LastName} - {item.Contact.Email} - {item.Contact.PhoneNumber} - {item.Address.StreetName} - {item.Address.PostalCode} - {item.Address.City} ");
        }
    }

}
