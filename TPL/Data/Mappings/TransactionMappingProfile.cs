using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Dtos.ProductDtos;
using TPL.Data.Dtos.TransactionDtos;
using TPL.Data.Entities;

namespace TPL.Data.Mappings
{
    public class TransactionMappingProfile : Profile
    {
        public TransactionMappingProfile()
        {
            CreateMap<TransactionCreateDto, Transaction>();
            CreateMap<TransactionResponseDto, Transaction>();
            CreateMap<Transaction, TransactionResponseDto>();
        }
    }
}
