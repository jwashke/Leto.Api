using Leto.Api.Models;
using Leto.Api.Resources;
using Leto.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace Leto.Api.Controllers
{
    public class AuthController : ApiController
    {
        private UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Logins a user by returning the user data and an access token
        /// </summary>
        /// <param name="user">User to be logged in, only need email and password</param>
        /// <returns>The User resource object with the new user info and an access token.</returns>
        [HttpPost]
        [ResponseType(typeof(UserResource))]
        public IHttpActionResult LoginUser([FromBody] User user)
        {
            try
            {
                var userResource = _userService.Login(user);
                return Ok(userResource);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
