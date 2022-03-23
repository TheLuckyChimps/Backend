using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Announcement : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Content { get; set; }
        public int Views { get; set; }
    }
}
