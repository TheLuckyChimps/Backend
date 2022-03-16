using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TPL.Data.Common.Interfaces
{
    public interface IManageEntity
    {
        DateTime CreatedAt { get; set; }
        Guid CreatedBy { get; set; }
        DateTime UpdatedAt { get; set; }
        Guid? UpdatedBy { get; set; }

        void OnCreate(Guid userId);
        void OnUpdate(Guid userId);
    }
}
