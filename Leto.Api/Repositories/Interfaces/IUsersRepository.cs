using Leto.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leto.Api.Repositories.Interfaces
{
    public interface IUserRepository
    {
        void Create(User user);
        void SaveChanges();
    }
}
