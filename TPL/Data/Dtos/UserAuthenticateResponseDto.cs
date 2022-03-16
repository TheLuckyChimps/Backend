using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Enums;

namespace TPL.Data.Dtos
{
    public class UserAuthenticateResponseDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
        public string Result { get; set; }
        public string Token { get; set; }
    }
}
