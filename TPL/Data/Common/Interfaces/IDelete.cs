using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common.Interfaces
{
    public interface IDelete
    {
        bool IsDeleted { get; set; }
        void SoftDelete();
    }
}