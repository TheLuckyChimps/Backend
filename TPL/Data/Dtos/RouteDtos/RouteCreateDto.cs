using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.RouteDtos
{
    public class RouteCreateDto
    {
        public string Name { get; set; }
        //public Guid BusId { get; set; }
        public string StartName { get; set; }
        public string StopName { get; set; }
    }
}
