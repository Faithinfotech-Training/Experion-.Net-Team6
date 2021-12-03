using cmsRestApi.Models;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        IUserRoleRepository repo;

        public UserRoleController(IUserRoleRepository repo)
        {
            this.repo = repo;
        }

        //Get All Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblUser>>> GetAllUsers()
        {
            return await repo.GetAllUsers();
        }

        //Get A User
        [HttpGet("id")]
        public async Task<IActionResult> GetAUser(int id)
        {
            try
            {
                var user = await repo.GetAUser(id);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        //Add User
        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] TblUser user)
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var User = await repo.AddUser(user);
                    if (User > 0)
                    {
                        return Ok(User);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //Update User
        [HttpPut]
        public async Task<IActionResult> PutUser(TblUser user)
        {
            try
            {
                var id = await repo.UpdateUser(user);
                if (id == 0)
                {
                    return NotFound();
                }
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
        
        //Delete User
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var uId = await repo.DeleteUser(id);
                if (uId == 0)
                {
                    return NotFound();
                }
                return Ok(uId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //GetAllRole
        [HttpGet("role")]
        public async Task<ActionResult<IEnumerable<TblRole>>> GetAllRole()
        {
            return await repo.GetAllRole();
        }

        //Add Role
        [HttpPost("role")]
        public async Task<IActionResult> AddRole([FromBody] TblRole role)  
        {
            //check the validation of body
            if (ModelState.IsValid)
            {
                try
                {
                    var roleId = await repo.AddRole(role);
                    if (roleId !=null)
                    {
                        return Ok(roleId);
                    }
                    else
                    {
                        return NotFound();
                    }

                }
                catch (Exception)
                {
                    return BadRequest();
                }
            }
            return BadRequest();
        }

        //update role
        [HttpPut("role")]
        public async Task<IActionResult> PutRole(TblRole role)
        {
            try
            {
                var id = await repo.UpdateRole(role);
                if (id == 0)
                {
                    return NotFound();
                }
                return Ok(id);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }


        //Delete Role
        [HttpDelete("role/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                var uId = await repo.DeleteRole(id);
                if (uId == 0)
                {
                    return NotFound();
                }
                return Ok(uId);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

    }
}
