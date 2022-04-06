using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.RouteDtos;
using TPL.Data.Dtos.StationDtos;

namespace TPL.Data.Dtos.RouteStationDtos
{
    public class RouteStationResponseDto
    {
        public Guid Id { get; set; }
        public RouteResponseDto Route { get; set; }
        public StationResponseDto Station { get; set; }
    }
}
