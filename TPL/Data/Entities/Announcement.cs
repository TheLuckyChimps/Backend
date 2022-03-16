using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Announcement : BaseEntity<Guid>
    {
        public int Views { get; set; }
    }
}
