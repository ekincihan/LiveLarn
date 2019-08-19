using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiveLarn.Service.Identity.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
