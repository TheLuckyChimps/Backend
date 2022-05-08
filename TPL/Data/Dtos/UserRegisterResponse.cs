using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos
{
    public class UserRegisterResponse
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
    }
}
