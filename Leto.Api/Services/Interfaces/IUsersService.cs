using Leto.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leto.Api.Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> All();
    }
}
