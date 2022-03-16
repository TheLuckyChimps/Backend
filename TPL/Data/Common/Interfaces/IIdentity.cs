using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common.Interfaces
{
    public interface IIdentity<TID>
    {
        TID Id { get; set; }
    }
}
