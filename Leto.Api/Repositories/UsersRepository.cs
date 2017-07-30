using Leto.Api.Models;
using Leto.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leto.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private LetoDbContext context { get; set; }

        public UserRepository(LetoDbContext _context)
        {
            context = _context;
        }

        public IEnumerable<User> All()
        {
            return context.Users.ToList();
        }
    }
}