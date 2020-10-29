using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeLamp.Models
{
    class UserRole
    {
        public string Role { get; set; }
        public List<User> Users { get; set; }
    }
}
