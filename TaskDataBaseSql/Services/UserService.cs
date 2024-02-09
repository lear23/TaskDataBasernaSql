

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;

namespace TaskDataBaseSql.Services;

public class UserService(UserRepo userRepo, RoleService roleService)
{
    private readonly UserRepo _userRepo = userRepo;
    private readonly RoleService _roleService = roleService;

    public UserEntity CreateUser(string playerName, string status, string roleName)
    {
        var roleEntity = _roleService.CreateRole(roleName);
        var userEntity = new UserEntity
        {
            PlayerName = playerName,
            Status = status,
            RoleId = roleEntity.Id.ToString(),
        };
        userEntity = _userRepo.Create(userEntity);
        return userEntity;
    }

    public UserEntity GetUserById(int id)
    {
        try
        {
            var userEntity = _userRepo.Get(x => x.Id == id);
            return userEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR GetIdUserService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<UserEntity> GetAllUsers()
    {
        try
        {
            var users = _userRepo.GetAll();
            return users;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllUsersService :: " + ex.Message); }
        return null!;
    }


    public UserEntity UpdateUser(UserEntity userEntity)
    {
        try
        {
            var updateUser = _userRepo.Update(x => x.Id == userEntity.Id, userEntity);
            return updateUser;

        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateUserService :: " + ex.Message); }
        return null!;
    }

    public void DeleteUser(int id)
    {
        try
        {
            _userRepo.Delete(x => x.Id == id);

        }
        catch (Exception ex) { Debug.WriteLine("ERROR DeleteUserService :: " + ex.Message); }

    }


    //public bool DeleteUser(Expression<Func<UserEntity, bool>> expression)
    //{
    //    try
    //    {
    //        var result = _userRepo.Delete(expression);
    //        return result;
    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteUserService :: " + ex.Message); }
    //    return false;

    //}




}
