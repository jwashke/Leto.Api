using Leto.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Leto.Api.Resources
{
    public class UserResource
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }
}