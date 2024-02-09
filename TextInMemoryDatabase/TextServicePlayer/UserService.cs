

using TextInMemoryDatabase.Repositories;
using TextInMemoryDatabase.TextEntities;

namespace TextInMemoryDatabase.TextServicePlayer;

public class UserService
{
    private readonly TextUserRepo _userRepo;

    public UserService(TextUserRepo userRepo)
    {
        _userRepo = userRepo;
    }

    public UserEntity CreateUser(string playerName, string status, int roleId)
    {
        var user = new UserEntity
        {
            PlayerName = playerName,
            Status = status,
            RoleId = roleId
        };

        return _userRepo.Create(user);
    }

    public IEnumerable<UserEntity> GetAllUsers()
    {
        return _userRepo.GetAll();
    }

    
}


