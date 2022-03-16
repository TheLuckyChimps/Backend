using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos;
using TPL.Data.Entities;
using TPL.Repository.Interfaces;
using TPL.Services.Interfaces;

namespace TPL.Services
{
    public class AnnouncementService : IAnnouncementService
    {
        private readonly IAnnouncementRepository announcementRepository;
        private readonly IMapper mapper;
       

        public AnnouncementService(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            this.announcementRepository = announcementRepository;
            this.mapper = mapper;
        }

        public async Task<List<AnnouncementResponseDto>> GetAllAnnouncements()
        {
            List<AnnouncementResponseDto> response = new List<AnnouncementResponseDto>();
            var announcements = await announcementRepository.GetAllUsersAsync();
            foreach (Announcement announcement in announcements)
            {
                var mappedAnnouncement = mapper.Map<AnnouncementResponseDto>(announcement);
                response.Add(mappedAnnouncement);
            }

            return response;
        }

        public async Task<AnnouncementResponseDto> GetById(Guid id)
        {

            var result = await announcementRepository.GetByIdAsync(id);

            return mapper.Map<AnnouncementResponseDto>(result);

        }
    }
}
