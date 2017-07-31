using Leto.Api.Models;
using Leto.Api.Repositories;
using Leto.Api.Resources;
using Leto.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leto.Api.Services
{
    public class UserService : IUserService
    {
        private UserRepository _userRepository { get; set; }
        private AuthService _authService { get; set; }

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
    }
}