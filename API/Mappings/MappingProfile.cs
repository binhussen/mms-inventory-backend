using AutoMapper;
using DataModel.Identity.Models;
using DataModel.Models.DTOs.Approve;
using DataModel.Models.DTOs.Customers;
using DataModel.Models.DTOs.Distribute;
using DataModel.Models.DTOs.Hrs;
using DataModel.Models.DTOs.Notify;
using DataModel.Models.DTOs.Requests;
using DataModel.Models.DTOs.Returns;
using DataModel.Models.DTOs.Stores;
using DataModel.Models.DTOs.User;
using DataModel.Models.DTOs.Warranty;
using DataModel.Models.Entities;

namespace API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Approve
            CreateMap<Approve, ApproveDto>();
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
            //Warranties

            CreateMap<CustomerWarranty, WarrantyDto>();
            CreateMap<WarrantiyForCreationDto, CustomerWarranty>();
            CreateMap<WarrantyForUpdateDto, CustomerWarranty>().ReverseMap();
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
            CreateMap<RequestItemForUpdateDto, RequestItem>().ReverseMap();
            //Distributes
            CreateMap<Distribute, DistributeDto>();
            CreateMap<DistributeForCreationDto, Distribute>();
            CreateMap<DistributeForUpdateDto, Distribute>();
            //Returns
            CreateMap<ReturnHeader, ReturnHeaderDto>();
            CreateMap<ReturnItem, ReturnItemDto>();
            CreateMap<ReturnHeaderForCreationDto, ReturnHeader>();
            CreateMap<ReturnItemForCreationDto, ReturnItem>();
            CreateMap<ReturnHeaderForUpdateDto, ReturnHeader>();
            CreateMap<ReturnItemForUpdateDto, ReturnItem>().ReverseMap();
            //Hrs
            CreateMap<HR, HrDto>();
            CreateMap<HrForCreationDto, HR>();
            CreateMap<HrForUpdateDto, HR>().ReverseMap();
        }
    }
}
