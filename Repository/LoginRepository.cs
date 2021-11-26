using cmsRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public class LoginRepository:ILoginRepository
    {
        //injecting databse
        ClinicManagementSystemDBContext db;

        public LoginRepository(ClinicManagementSystemDBContext db)
        {
            this.db = db;

        }

        //Get user by username and password using Get method
        public async Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd)
        {
            if (db != null)
            {
                TblUser user = await db.TblUser.FirstOrDefaultAsync(u => u.UserName == un && u.Password == pwd);
                if (user != null)
                {
                    return user;

                }
                return null;
            }
            return null;
        }

        //validate user
        public TblUser validateUser(string username, string password)
        {
            if (db != null)
            {
                TblUser user = db.TblUser.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    return user;
                }
                return null;
            }
            return null;
        }

    }
}
