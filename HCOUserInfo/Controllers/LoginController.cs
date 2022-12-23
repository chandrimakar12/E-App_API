using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HCOUserInfo.Repository;
using HCOUserInfo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace HCOUserInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IAuthorizationService _authContext;
        public LoginController(IAuthorizationService auth)
        {
            _authContext = auth;
        }

        [HttpPost("login")]
        public ActionResult Authenticate([FromBody] Authorization userobj)
        {
            try
            {
                var obj = _authContext.GetDetails(userobj.UserName);
                Console.WriteLine(obj);
                Console.WriteLine($"Password in userdetail is {userobj.Password}");
                if (obj == null)
                {
                    return NotFound($"Username {userobj.UserName} is invalid");
                }
                else if (obj.Password != userobj.Password)
                {
                    return NotFound($"Incorrect Password");
                }
               /* else if (obj.Roles.ToUpper() != userobj.Roles.ToUpper())
                {
                    return NotFound($"Please select correct user role");
                }*/
                else
                {
                    obj.Token = CreateJwt(obj);

                    return Ok(new
                    {
                        Token=obj.Token,
                        isloggedin = "true",
                        Message = ($"Login Successful , Welcome {obj.UserName} !!")
                    }); //($"Welcome {obj.FirstName} {obj.LastName}")
                }
            }
            catch (Exception e)
            {
                return NotFound($"{e} has occured");
            }
        }

        

        private string CreateJwt(Authorization auth)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("veryverysecret.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, auth.Roles),
                new Claim(ClaimTypes.Name,$"{auth.UserName}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}
