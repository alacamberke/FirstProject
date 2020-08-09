using Dal.Abstract;
using Dal.Concrete;
using Dtos;
using Microsoft.IdentityModel.Tokens;
using NormalApi.Logging;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Web.Http;

namespace NormalApi.Controllers
{
    [Logging]
    public class AuthController : ApiController
    {
        private IAuthRepository _authService;
        public AuthController()
        {
            _authService = new AuthRepository(new Dal.Context());
        }

        [Route("api/Auth/register")]
        [HttpPost]
        public IHttpActionResult Register([FromBody]Register registeruser) // ---> Register is in UserDTO.
        {
            if(_authService.Register(registeruser) == false)
            {
                return Unauthorized();
            }
            else if (ModelState.IsValid)
            {
                return Created("","Welcome " + registeruser.UserName);
            }
            return null;
        }

        [HttpPost]
        [Route("api/Auth/login")]
        public IHttpActionResult Login([FromBody]Login login) // ---> Login is in UserDTO.
        {
            var user = _authService.Login(login);
            if(user != null)
            {
                //Login Token operations.
                var key = Encoding.ASCII.GetBytes("this.is.my.key.777111445319");
                var tokenHandler = new JwtSecurityTokenHandler();
                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, login.UserName),
                    }),

                    Expires = DateTime.Now.AddMinutes(15),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };
                tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenDescriptor.ToString();
                Ok(tokenString);
            }
            return Unauthorized();
        }

        [Route("api/Auth/getall")]
        [HttpGet]
        public IHttpActionResult GetAllUsers()
        {
            var users = _authService.GetAllUsers();
            if(users == null)
            {
                return NotFound();
            }
            return Ok(users);
        }

        [Route("api/Auth/get/{id}")]
        public IHttpActionResult GetUser(int id)
        {
            var user = _authService.GetUser(id);
            if(user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
    }
}
