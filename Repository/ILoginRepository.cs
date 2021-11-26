using cmsRestApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Repository
{
    public interface ILoginRepository
    {
        //operations

        Task<ActionResult<TblUser>> GetUserByPassword(string un, string pwd);

        public TblUser validateUser(string username, string password);
    }
}
