

using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextConsoleApp.TextRepositories;

public class MainAddress(TextAddressRepo textRepo)
{

    private readonly TextAddressRepo _textRepo = textRepo;

    public void CreateAddress()
    {

        
        var address = new AddressEntity();

        Console.Clear();

        Console.Write("Streetname: ");
        address.StreetName = Console.ReadLine()!;

        Console.Write("PostalCode . ");
        address.PostalCode = Console.ReadLine()!;

        Console.Write("City :");
        address.City = Console.ReadLine()!;

       var entity = _textRepo.Create(address);
        Console.WriteLine($"Address ID : {entity.Id} ");


        Console.ReadKey();

    }

    public void ListAllAddres()
    {
        Console.Clear();
        var address = _textRepo.GetAll();
        foreach ( var item in address )
        {
            Console.WriteLine($"{item.StreetName} - {item.PostalCode} - {item.City} ");
        }
    }




}
