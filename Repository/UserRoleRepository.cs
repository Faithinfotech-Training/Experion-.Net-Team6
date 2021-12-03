using cmsRestApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        //Database Injection
        ClinicManagementSystemDBContext db;

        public UserRoleRepository(ClinicManagementSystemDBContext db)
        {
            this.db = db;
        }

        public async Task<List<TblUser>> GetAllUsers()
        {
            if (db != null)
            {
                return await db.TblUser.ToListAsync();
            }
            return null;
        }

        public async Task<TblUser> GetAUser(int id)
        {
            if (db != null)
            {
                var user = await db.TblUser.FirstOrDefaultAsync(u => u.UserId == id);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            return null;

        }

        public async Task<int> AddUser(TblUser user)
        {
            if (db != null)
            {
                await db.TblUser.AddAsync(user);
                await db.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }

        public async Task<int> UpdateUser(TblUser user)
        {
            if (db != null)
            {
                db.TblUser.Update(user);
                await db.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }

        public async Task<int> DeleteUser(int id)
        {
            if (db != null)
            {
                var user = await db.TblUser.FirstOrDefaultAsync(u => u.UserId == id);
                user.IsActive = false;
                await db.SaveChangesAsync();
                return user.UserId;
            }
            return 0;
        }





        public async Task<List<TblRole>> GetAllRole()
        {
            if (db != null)
            {
                return await db.TblRole.ToListAsync();
            }
            return null;
        }


        public async Task<TblRole> AddRole(TblRole role)
        {
            if (db != null)
            {
                await db.TblRole.AddAsync(role);
                await db.SaveChangesAsync();
                return role;
            }
            return null;
        }


        public async Task<int> UpdateRole(TblRole role)
        {
            if (db != null)
            {
                db.TblRole.Update(role);
                await db.SaveChangesAsync();
                return role.RoleId;
            }
            return 0;
        }

        public async Task<int> DeleteRole(int id)
        {
            if (db != null)
            {
                var role = await db.TblRole.FirstOrDefaultAsync(u => u.RoleId== id);
                role.IsActive = false;
                await db.SaveChangesAsync();
                return role.RoleId;
            }
            return 0;
        }



    }
}

