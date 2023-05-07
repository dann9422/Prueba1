﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba1.Helpers;
using Prueba1.Models.DataModels;

namespace Prueba1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {

        private readonly JwtSettings _jwtSetthings;


        public AccountController(JwtSettings jwtSetthings)
        {
            _jwtSetthings = jwtSetthings;

        }
        private IEnumerable<User> Logins = new List<User>()
        {
            new User(){
            Id = 1,
            Email = "daniel@gmail.com",
            Name = "daniel",
            PassWord="daniel"

            },

            new User(){
            Id = 2,
            Email = "juan@gmail.com",
            Name = "juan",
            PassWord="juan"

            }

        };

    [HttpPost]
        public IActionResult GetToken (UserLogin userLogin)
        {
            try
            {
                var Token = new UserTokens();
                var Valid = Logins.Any(User => User.Name.Equals(userLogin.UserName,StringComparison.OrdinalIgnoreCase));

                if (Valid)
                {
                    var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = user.Name,
                        EmailId = user.Email,
                        Id = user.Id,
                        GuidId = Guid.NewGuid()



                    },_jwtSetthings) ;

                }
                else
                {
                    return BadRequest("Whong password");
                }
                return Ok(Token);

            }
            catch (Exception ex)
            {

                throw new Exception(" Get Token error ", ex);
            }
        }
        [HttpGet]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme,Roles ="Administrator")]
        public IActionResult GetUserList()
        {
            return Ok(Logins);
        }

         
    }
}