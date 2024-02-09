

using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextConsoleApp.TextRepositories;

public class MainContact(TextContactRepo contactRepo)
{
    private readonly TextContactRepo _contactRepo = contactRepo;

    public void CreateContact()
    {


        var contact = new ContactEntity();

        Console.Clear();

        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;

        Console.Write("PhoneNumber . ");
        contact.PhoneNumber = Console.ReadLine()!;

        

        var entity = _contactRepo.Create(contact);
        Console.WriteLine($"Address ID : {entity.Id} ");


        Console.ReadKey();

    }

    public void ListAllContact()
    {
        Console.Clear();
        var address = _contactRepo.GetAll();
        foreach (var item in address)
        {
            Console.WriteLine($"{item.Email} - {item.PhoneNumber} ");
        }
    }



}
