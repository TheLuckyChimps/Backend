using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos;

namespace TPL.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<List<AnnouncementResponseDto>> GetAllAnnouncements();
        Task<AnnouncementResponseDto> GetById(Guid id);
    }
}
