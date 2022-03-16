using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<UserCreateDto, User>();
            CreateMap<UserResponseDto, User>();
            CreateMap<UserUpdateDto, User>();
            CreateMap<User, UserResponseDto>();
            CreateMap<User, UserUpdateDto>();
            CreateMap<UserAuthenticateDto, UserAuthenticateResponseDto>();
            CreateMap<UserAuthenticateResponseDto, UserAuthenticateDto>();
        }
        
    }
}
