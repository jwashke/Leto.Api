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

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<User> All()
        {
            return _userRepository.All();
        }

        public UserResource Create(User newUser)
        {
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(newUser.Password);

            _userRepository.Create(newUser);
            _userRepository.SaveChanges();

            var userResource = new UserResource();
            userResource.User = newUser;

            // Generate token here

            return userResource;
        }
    }
}