using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;

namespace TPL.Data.Entities
{
    public class Line : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public List<Station> Stations { get; set; }
        public List<Bus> Buses { get; set; }
    }
}
