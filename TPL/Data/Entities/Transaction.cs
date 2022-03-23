using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Transaction : BaseEntity<Guid>
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
    }
}
