using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Leto.Api.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required,MaxLength(30),Index(IsUnique = true)]
        public string Email { get; set; }

        [Required,MaxLength(30)]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}