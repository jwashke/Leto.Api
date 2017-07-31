using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leto.Api.Services.Interfaces
{
    public interface IAuthService
    {
        string CreateToken(string userEmail);
    }
}
