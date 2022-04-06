using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Route : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid BusId { get; set; }
        //public List<string> StationNames { get; set; }
        public string StartName { get; set; }
        public string StopName { get; set; }
        public virtual List<RouteStation> RouteStation { get; set; }
        // public List<Bus> Buses { get; set; }
    }
}
