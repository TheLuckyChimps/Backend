﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Dtos.BusDtos
{
    public class BusCreateDto
    {
        public string Name { get; set; }
        public Guid LineId { get; set; }
        public int Places { get; set; }
        public bool Eco { get; set; }
        public int Number { get; set; }
        public string Driver { get; set; }
    }
}
