using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MedicApp.Data.Entities.Admin
{
    public class User:BaseEntity
    {
        public string Fullname { get; set; }
        public string Token { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool isAdmin { get; set; }
    }
}
