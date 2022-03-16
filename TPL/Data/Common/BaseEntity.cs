using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Common.Interfaces;

namespace TPL.Data.Common
{
    public class BaseEntity<TID> : IIdentity<TID>, IDelete, IManageEntity where TID : struct
    {
        public TID Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }

        public void OnCreate(Guid userId)
        {
            CreatedAt = DateTime.UtcNow;
            CreatedBy = userId;
        }

        public void OnUpdate(Guid userId)
        {
            UpdatedAt = DateTime.UtcNow;
            UpdatedBy = userId;
        }

        public void SoftDelete()
        {
            IsDeleted = true;
        }
    }
}
