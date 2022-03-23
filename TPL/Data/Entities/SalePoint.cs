using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common;
using TPL.Data.Enums;

namespace TPL.Data.Entities
{
    public class SalePoint : BaseEntity<Guid>
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public SalePointType SalePointType { get; set; }
    }
}
