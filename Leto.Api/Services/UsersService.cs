using Leto.Api.Models;
using Leto.Api.Repositories;
using Leto.Api.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leto.Api.Services
{
    public class UserService : IUserService
    {
        private UserRepository userRepository { get; set; }

        public UserService(UserRepository _userRepository)
        {
            userRepository = _userRepository;
        }

        public IEnumerable<User> All()
        {
            return userRepository.All();
        }
    }
}