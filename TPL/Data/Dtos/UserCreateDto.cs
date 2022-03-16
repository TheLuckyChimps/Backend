using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Enums;

namespace TPL.Data.Dtos
{
    public class UserCreateDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
       // public UserRole userRole { get; set; }

    }
}
