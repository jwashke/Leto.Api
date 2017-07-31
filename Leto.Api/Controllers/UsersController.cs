using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Leto.Api.Models;
using Leto.Api.Services;
using Leto.Api.Services.Interfaces;
using Leto.Api.Resources;

namespace Leto.Api.Controllers
{
    public class UsersController : ApiController
    {
        private IUserService userService;

        public UsersController(IUserService _userService)
        {
            userService = _userService;
        }

        /// <summary>
        /// Creates a new User and returns the user info along with a jwt access token.
        /// </summary>
        /// <param name="newUser">The User object to be created.</param>
        /// <returns></returns>
        [ResponseType(typeof(UserResource))]
        public IHttpActionResult CreateUser([FromBody] User newUser)
        {
            try
            {
                var user = userService.Create(newUser);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest("An error has occurred: " + ex.Message);
            }
        }
    }
}