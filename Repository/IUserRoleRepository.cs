using cmsRestApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface IUserRoleRepository
    {
        //operations

        //USER
        Task<List<TblUser>> GetAllUsers();
        Task<TblUser> GetAUser(int id);
        Task<int> AddUser(TblUser user);
        Task<int> UpdateUser(TblUser user);
        Task<int> DeleteUser(int id);

        //ROLE
        Task<List<TblRole>> GetAllRole();
        Task<TblRole> AddRole(TblRole role);
        Task<int> UpdateRole(TblRole role);
        Task<int> DeleteRole(int id);

    }
}
