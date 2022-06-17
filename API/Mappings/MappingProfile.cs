using AutoMapper;
using DataModel.Identity.Models;
using DataModel.Models.DTOs.Approve;
using DataModel.Models.DTOs.Distribute;
using DataModel.Models.DTOs.Notify;
using DataModel.Models.DTOs.Customers;
using DataModel.Models.DTOs.Requests;
using DataModel.Models.DTOs.Stores;
using DataModel.Models.DTOs.User;
using DataModel.Models.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Approve
            CreateMap<ApproveForCreationDto, Approve>();
            CreateMap<RequestItemStatus, RequestItem>().ReverseMap();
            //CreateMap<StoreItemAvailableQuantity, StoreItem>().ReverseMap();
            CreateMap<StoreItemAvailableQuantity, StoreItem>();
            // Users
            CreateMap<ApplicationUser, AcountResponse>();
            CreateMap<UserForRegistrationDto, ApplicationUser>();
            CreateMap<UserForUpdateDto, ApplicationUser>().ReverseMap();
            //Customers
            CreateMap<Customer, CustomerDto>();
            CreateMap<CustomerForCreationDto, Customer>();
            CreateMap<CustomerForUpdateDto, Customer>();
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
            //Distributes
            CreateMap<Distribute, DistributeDto>();
            CreateMap<DistributeForCreationDto, Distribute>();
            CreateMap<DistributeForUpdateDto, Distribute>();
        }
    }
}
