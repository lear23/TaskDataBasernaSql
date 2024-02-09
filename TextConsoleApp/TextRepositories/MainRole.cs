

using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextConsoleApp.TextRepositories;

public class MainRole(TextRoleRepo textRepo)
{
    private readonly TextRoleRepo _textRepo = textRepo;

    public void CreateRole()
    {


        var role = new RoleEntity();

        Console.Clear();

        Console.Write("Rolename: ");
        role.RoleName = Console.ReadLine()!;

      

        var entity = _textRepo.Create(role);
        Console.WriteLine($"Address ID : {entity.Id} ");


        Console.ReadKey();

    }

    public void ListAllRolle()
    {
        Console.Clear();
        var address = _textRepo.GetAll();
        foreach (var item in address)
        {
            Console.WriteLine($"{item.RoleName} ");
        }
    }
}
