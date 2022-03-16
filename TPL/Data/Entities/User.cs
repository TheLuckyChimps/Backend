using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;
using TPL.Data.Enums;

namespace TPL.Data.Entities
{
    public class User : BaseEntity<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public UserRole Role { get; set; }
    }
}
