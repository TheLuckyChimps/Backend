using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.RouteDtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class RouteMappingProfile : Profile
    {
        public RouteMappingProfile()
        {
            CreateMap<RouteCreateDto, Route>();
            CreateMap<RouteResponseDto, Route>();
            CreateMap<RouteUpdateDto, Station>();
            CreateMap<Route, RouteResponseDto>();
            CreateMap<Station, RouteUpdateDto>();
        }
    }
}
