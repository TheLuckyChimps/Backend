using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.StationDtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class StationMappingProfile : Profile
    {
        public StationMappingProfile()
        {
            CreateMap<StationCreateDto, Station>();
            CreateMap<StationResponseDto, Station>();
            CreateMap<StationUpdateDto, Station>();
            CreateMap<Station, StationResponseDto>();
            CreateMap<Station, StationUpdateDto>();
        }
    }
}
