using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;
using TPL.Data.Enums;

namespace TPL.Data.Entities
{
    public class Bus : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public Guid LineId { get; set; }
        public int Places { get; set; }
        public bool Eco { get; set; }
        public int Number { get; set; }
        public string Driver { get; set; }
       // public Line Line { get; set; }
    }
}
