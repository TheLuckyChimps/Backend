using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class RouteStation : BaseEntity<Guid>
    {
        public Guid StationId { get; set; }
        public Guid LineId { get; set; }
        public virtual Route Route { get; set; }
        public virtual Station Station { get; set; }
    }
}
