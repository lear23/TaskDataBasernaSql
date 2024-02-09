
using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextConsoleApp.TextRepositories;

public class MainUser(TextUserRepo textRepo)
{

    private readonly TextUserRepo _textRepo = textRepo;

    public void CreateUser()
    {
        var user = new UserEntity
        {
            Role = new RoleEntity(),

        };



        Console.Clear();

        Console.Write("PlayerName: ");
        user.PlayerName = Console.ReadLine()!;

        Console.Write("Status :  ");
        user.Status = Console.ReadLine()!;

        Console.Write("RoleName : ");
        user.Role.RoleName =Console.ReadLine()!;


        var entity = _textRepo.Create(user);
        Console.WriteLine($"User ID : {entity.Id} ");


        Console.ReadKey();

    }

    public void ListAllUser()
    {
        Console.Clear();
        var user = _textRepo.GetAll();
        foreach (var item in user)
        {
            Console.WriteLine($"{item.PlayerName} - {item.Status} - {item.Role.RoleName} ");
        }
    }
}