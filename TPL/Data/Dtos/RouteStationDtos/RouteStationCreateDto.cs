using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.RouteStationDtos
{
    public class RouteStationCreateDto
    {
        public Guid StationId { get; set; }
        public Guid RouteId { get; set; }
    }
}
