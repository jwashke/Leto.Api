using Leto.Api.Models;
using Leto.Api.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Leto.Api.Repositories
{
    public class UserRepository : IUserRepository
    {
        private LetoDbContext _context { get; set; }

        public UserRepository(LetoDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> All()
        {
            return _context.Users.ToList();
        }

        public void Create(User user)
        {
            _context.Users.Add(user);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}