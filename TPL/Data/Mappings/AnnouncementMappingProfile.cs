using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class AnnouncementMappingProfile : Profile
    {
        public AnnouncementMappingProfile()
        {
            CreateMap<AnnouncementResponseDto, Announcement>();
            CreateMap<Announcement, AnnouncementResponseDto>();
        }
    }
}
