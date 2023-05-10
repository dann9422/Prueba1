using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba1.Data;
using Prueba1.Helpers;
using Prueba1.Models.DataModels;

namespace Prueba1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UniversityDBContext _context;

        private readonly JwtSettings _jwtSetthings;


        public AccountController(UniversityDBContext context,JwtSettings jwtSetthings)
        {
            _context = context;
            _jwtSetthings = jwtSetthings;
            
        }
        private IEnumerable<User> Logins = new List<User>()
        {
            new User(){
            Id = 1,
            Email = "daniel@gmail.com",
            Name = "Admin",
            PassWord="Admin"

            },

            new User(){
            Id = 2,
            Email = "juan@gmail.com",
            Name = "User 1",
            PassWord="pepe"

            }

        };

    [HttpPost]
        public IActionResult GetToken (UserLogin userLogin)
        {
            try
            {
                var Token = new UserTokens();



                //Consulta desde la base de datos creados 
                var searchUser = (from user in _context.Users
                                 where user.Name == userLogin.UserName
                                 && user.PassWord == userLogin.Password
                                 select user).FirstOrDefault();


                //Console.WriteLine("User found", searchUser);


                //var Valid = Logins.Any(User => User.Name.Equals(userLogin.UserName,StringComparison.OrdinalIgnoreCase));

                var valid = searchUser != null; 


                if (searchUser != null)
                {
                    //var user = Logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName));

                    Token = JwtHelpers.GenTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
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
