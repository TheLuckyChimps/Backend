using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.BusDtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class BusMappingProfile : Profile
    {
        public BusMappingProfile()
        {
            CreateMap<BusCreateDto, Bus>();
            CreateMap<BusResponseDto, Bus>();
            CreateMap<BusUpdateDto, Bus>();
            CreateMap<Bus, BusResponseDto>();
            CreateMap<Bus, BusUpdateDto>();
        }
    }
}
