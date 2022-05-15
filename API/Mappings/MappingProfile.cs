using System;
using AutoMapper;
using DataModel.Models.DTOs;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NotifyHeader, NotifyHeaderDto>().ReverseMap();
            CreateMap<NotifyDetail, NotifyDetailDto>().ReverseMap();
            CreateMap<NotifyHeaderForCreationDto, NotifyHeader>().ReverseMap();
            CreateMap<NotifyDetailForCreationDto, NotifyDetail>().ReverseMap();
            CreateMap<NotifyHeaderForUpdateDto, NotifyHeader>().ReverseMap();
            CreateMap<NotifyDetailForUpdateDto, NotifyDetail>().ReverseMap();
        }
    }
}
