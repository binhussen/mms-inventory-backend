﻿using System;
using AutoMapper;
using DataModel.Models.DTOs;
using System.Threading.Tasks;
using DataModel.Models.Entities;
using System.Collections.Generic;
using DataModel.Models.DTOs.Requests;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Notifies
            CreateMap<NotifyHeader, NotifyHeaderDto>();
            CreateMap<NotifyItem, NotifyItemDto>();
            CreateMap<NotifyHeaderForCreationDto, NotifyHeader>();
            CreateMap<NotifyItemForCreationDto, NotifyItem>();
            CreateMap<NotifyHeaderForUpdateDto, NotifyHeader>();
            CreateMap<NotifyItemForUpdateDto, NotifyItem>().ReverseMap();
            //Stores
            CreateMap<StoreHeader, StoreHeaderDto>();
            CreateMap<StoreItem, StoreItemDto>();
            CreateMap<StoreHeaderForCreationDto, StoreHeader>();
             CreateMap<StoreItemForCreationDto, StoreItem>();
            CreateMap<StoreHeaderForUpdateDto, StoreHeader>();
            CreateMap<StoreItemForUpdateDto, StoreItem>().ReverseMap();
            //Requests
            CreateMap<RequestHeader, RequestHeaderDto>();
            CreateMap<RequestItem, RequestItemDto>();
            CreateMap<RequestHeaderForCreationDto, RequestHeader>();
            CreateMap<RequestItemForCreationDto, RequestItem>();
            CreateMap<RequestHeaderForUpdateDto, RequestHeader>();
            CreateMap<RequestItemForUpdateDto, RequestItemForUpdateDto>().ReverseMap();
        }
    }
}