using Leto.Api.Models;
using Leto.Api.Repositories;
using Leto.Api.Resources;
using Leto.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Leto.Api.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository;
        private AuthService _authService;

        public UserService(UserRepository userRepository, AuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public UserResource Create(User newUser)
        {
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            _userRepository.Create(newUser);
            _userRepository.SaveChanges();

            var userResource = new UserResource();
            userResource.Id = newUser.Id;
            userResource.Name = newUser.Name;
            userResource.Email = newUser.Email;

            // Generate token here
            string token = _authService.CreateToken(userResource.Email);
            userResource.AccessToken = token;

            return userResource;
        }

        public UserResource Login(User user)
        {
            var foundUser = _userRepository.FindByEmail(user.Email);

            if (foundUser != null)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, foundUser.Password))
                {
                    var userResource = new UserResource();
                    userResource.Id = foundUser.Id;
                    userResource.Name = foundUser.Name;
                    userResource.Email = foundUser.Email;

                    string token = _authService.CreateToken(userResource.Email);
                    userResource.AccessToken = token;

                    return userResource;
                }
                else
                {
                    throw new Exception("Invalid Credentials");
                }
            }
            else
            {
                throw new Exception("Invalid Credentials");
            }
        }
    }
}