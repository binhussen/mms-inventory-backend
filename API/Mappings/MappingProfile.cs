using AutoMapper;
using DataModel.Identity.Models;
using DataModel.Models.DTOs;
using DataModel.Models.DTOs.Approve;
using DataModel.Models.DTOs.Requests;
using DataModel.Models.DTOs.User;
using DataModel.Models.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Users
            CreateMap<ApplicationUser, AcountResponse>();
            CreateMap<UserForRegistrationDto, ApplicationUser>();
            CreateMap<UserForUpdateDto, ApplicationUser>();
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
            CreateMap<RequestItem, RequestItemApproveDto>();
            CreateMap<RequestHeaderForCreationDto, RequestHeader>();
            CreateMap<RequestItemForCreationDto, RequestItem>();
            CreateMap<RequestHeaderForUpdateDto, RequestHeader>();
            CreateMap<RequestItemForUpdateDto, RequestItem>().ReverseMap();
            //Approve
            CreateMap<ApproveForCreationDto, Approve>();
        }
    }
}
