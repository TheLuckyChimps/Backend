using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.StationDtos
{
    public class StationByRouteIdDto
    {
        public Guid LineId { get; set; }
        public StationResponseDto Station { get; set; }
    }
}
