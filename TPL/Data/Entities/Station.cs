using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Station : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public List<Line> Lines { get; set; }

    }
}
