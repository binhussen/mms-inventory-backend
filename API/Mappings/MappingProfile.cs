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
            CreateMap<NotifyHeader, NotifyHeaderDto>();
            CreateMap<NotifyDetail, NotifyDetailDto>();
            CreateMap<NotifyHeaderForCreationDto, NotifyHeader>();
            CreateMap<NotifyDetailForCreationDto, NotifyDetail>();
            CreateMap<NotifyHeaderForUpdateDto, NotifyHeader>();
            CreateMap<NotifyDetailForUpdateDto, NotifyDetail>().ReverseMap();
        }
    }
}
