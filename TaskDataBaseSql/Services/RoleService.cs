

using System.Diagnostics;
using System.Linq.Expressions;
using TaskDataBaseSql.Entities;
using TaskDataBaseSql.PlayerRepo;

namespace TaskDataBaseSql.Services;

public class RoleService
{
    private readonly RoleRepo _roleRepo;

    public RoleService(RoleRepo roleRepo)
    {
        _roleRepo = roleRepo;
    }

    public RoleEntity CreateRole(string roleName)
    {
        try
        {
            var roleEntity = _roleRepo.Get(x => x.RoleName == roleName);
            if (roleEntity == null) {
                {
                    roleEntity = _roleRepo.Create(new RoleEntity { RoleName = roleName});
                } }
            return roleEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateRoleService :: " + ex.Message); }
        return null!;
    }
    public RoleEntity GetRoleByName(string roleName)
    {
        try
        {
            var roleEntity = _roleRepo.Get(x => x.RoleName == roleName);
            return roleEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetRoleService :: " + ex.Message); }
        return null!;

    }

    public RoleEntity GetRoleById(int id)
    {
        try
        {
            var roleEntity = _roleRepo.Get(x => x.Id == id);
            return roleEntity;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetIdRoleService :: " + ex.Message); }
        return null!;
    }
    public IEnumerable<RoleEntity> GetAllRole()
    {
        try
        {
            var roles = _roleRepo.GetAll();
            return roles;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR CreateGetAllRoleService :: " + ex.Message); }
        return null!;
    }


    public RoleEntity UpdateRole(RoleEntity roleEntity)
    {
        try
        {
            var updateRole = _roleRepo.Update(x => x.Id == roleEntity.Id, roleEntity);
            return updateRole;
           
        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateRoleService :: " + ex.Message); }
        return null!;
    }

    //public void DeleteRole(int id)
    //{
    //    try
    //    {
    //        _roleRepo.Delete(x => x.Id == id);

    //    }
    //    catch (Exception ex) { Debug.WriteLine("ERROR DeleteRoleService :: " + ex.Message); }
       
    //}


    public bool DeleteRole(Expression<Func<RoleEntity, bool>> expression)
    {
        try
        {
            var result = _roleRepo.Delete(expression);
            return result;
        }
        catch (Exception ex) { Debug.WriteLine("ERROR UpdateRoleService :: " + ex.Message); }
        return false;

    }

}
