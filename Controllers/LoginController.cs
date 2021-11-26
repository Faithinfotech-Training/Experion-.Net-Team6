using cmsRestApi.Models;
using cmsRestApi.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cmsRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //dependency injection for configuration
        //1
        private IConfiguration _config;

        //2
        ILoginRepository repo;

        //Dependency injection
        public LoginController(IConfiguration config, ILoginRepository repo)
        {
            _config = config;
            this.repo = repo;
        }

        //Getting token ,username and RoleId
        [AllowAnonymous]
        [HttpGet("{userName}/{password}")]

        public IActionResult Login(string userName, string password)
        {
            IActionResult response = Unauthorized();
            //Authenticate the user
            var user = AuthenticateUser(userName, password);

            //validate
            if (user != null)
            {
                var tokenString = GenerateJSONWebToken(user);
                response = Ok(new
                {
                    uName = user.UserName,
                    RoleId = user.RoleId,
                    token = tokenString
                });
            }
            return response;
        }

        //GETTING USER USING GET
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet("getuser/{userName}/{password}")]
        public async Task<ActionResult<TblUser>> GetUserByPassWord(string userName, String password)
        {
            try
            {
                var dbUser = await repo.GetUserByPassword(userName, password);
                if (dbUser == null)
                {
                    return NotFound();
                }
                return dbUser;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


        //GenerateJSON Web Token
        private string GenerateJSONWebToken(TblUser user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));

            //signing credential
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //Generate token
            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //AuthenticateUser
        private TblUser AuthenticateUser(string userName, string password)
        {
            TblUser user = null;

            user = repo.validateUser(userName, password);
            if (user != null)
            {
                return user;
            }

            return user;

        }

    }
}
