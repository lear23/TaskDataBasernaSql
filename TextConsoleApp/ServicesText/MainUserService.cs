

using TextInMemoryDatabase.TextServicePlayer;

namespace TextConsoleApp.ServicesText;

public class MainUserService
{
    private readonly UserService _userService;

    public MainUserService(UserService userService)
    {
        _userService = userService;
    }

    public void CreateUserService()
    {
        Console.Clear();

        Console.Write("PlayerName: ");
        var playerName = Console.ReadLine()!;

        Console.Write("Status: ");
        var status = Console.ReadLine()!;

        Console.Write("RoleId: ");
        if (!int.TryParse(Console.ReadLine(), out int roleId))
        {
            Console.WriteLine("Error: RoleId must be a number.");
            return;
        }

        var newUser = _userService.CreateUser(playerName, status, roleId);
        if (newUser != null)
        {
            Console.WriteLine($"User created with ID: {newUser.Id}");
        }
        else
        {
            Console.WriteLine("Error creating user.");
        }

        Console.ReadKey();
    }

    public void ListAllUserService()
    {
        Console.Clear();
        var allUsers = _userService.GetAllUsers();
        Console.WriteLine("All users:");
        foreach (var user in allUsers)
        {
            Console.WriteLine($"{user.PlayerName} - {user.Status} - {user.Role.RoleName}");
        }
        Console.ReadKey();
    }
}


