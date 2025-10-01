using AutoMapper;
using Shipping.BL.DTOs.Auth.Role;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Delivery;
using Shipping.BL.DTOs.Employee;
using Shipping.BL.DTOs.Governorate;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.OrderReport;
using Shipping.BL.DTOs.product;
using Shipping.BL.DTOs.ShippingType;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.BL.DTOs.Village;
using Shipping.BL.DTOs.Weight;
using Shipping.DAL.Entities;
using Shipping.DAL.Entities.Identity;
using Shipping.PL.DTOs.Governorate;

namespace Shipping.BL.Mappers
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<City, ReadCityDTO>().ReverseMap();
            CreateMap<City, AddCityDTO>().ReverseMap();
            CreateMap<Governorate, AddGovernorateDTO>().ReverseMap();
            CreateMap<Governorate, ReadGovernorateDTO>().ReverseMap();
            CreateMap<Branches, AddBrachDTO>().ReverseMap();
            CreateMap<Branches, ReadBranchDTO>().ReverseMap();

            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<Product, ReadProductDTO>().ReverseMap();
            CreateMap<SpecialPackages, ReadPackageDto>().ReverseMap();
            CreateMap<SpecialPackages, AddPackageDto>().ReverseMap();

            CreateMap<AddShippingTypeDTO, ShippingType>().ReverseMap();
            CreateMap<ShippingType, ReadShippingTypeDTO>().ReverseMap();
            CreateMap<WeightPrice, ReadWeightDTO>().ReverseMap();
            CreateMap<WeightPrice, AddWeightDTO>().ReverseMap();

            CreateMap<VillageDelivery, ReadVillageDTO>().ReverseMap();
            CreateMap<VillageDelivery, AddVillageDTO>().ReverseMap();

            CreateMap<AddOrderDTO, Order>().ReverseMap();

            CreateMap<Order, ReadOrderDTO>()
                .ForMember(dest => dest.Governorate,
                           opt => opt.MapFrom(src => src.Governorate != null ? src.Governorate.Name : string.Empty))
                .ForMember(dest => dest.City,
                           opt => opt.MapFrom(src => src.City != null ? src.City.Name : string.Empty))
                .ForMember(dest => dest.merchntName,
                           opt => opt.MapFrom(src => src.Merchant != null ? src.Merchant.User.UserName : string.Empty))
                .ForMember(dest => dest.BranchName,
                           opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : string.Empty))
                .ReverseMap();

            CreateMap<Order, EditOrderDTO>()
                .ForMember(dest => dest.MerchentId, opt => opt.MapFrom(src => src.MerchantId))
                .ForMember(dest => dest.branchId, opt => opt.MapFrom(src => src.BranchId))
                .ForMember(dest => dest.CityId, opt => opt.MapFrom(src => src.CityId))
                .ForMember(dest => dest.GovernorateId, opt => opt.MapFrom(src => src.GovernorateId))
                .ForMember(dest => dest.ShippingTypeId, opt => opt.MapFrom(src => src.ShippingTypeId))
                .ForMember(dest => dest.IsVillageDelivery, opt => opt.MapFrom(src => src.IsVillageDelivery))
                .ForMember(dest => dest.Phonenumber,
                           opt => opt.MapFrom(src => src.Merchant != null ? src.Merchant.User.PhoneNumber : string.Empty))
                .ForMember(dest => dest.Address,
                           opt => opt.MapFrom(src => src.Merchant != null ? src.Merchant.User.Address : string.Empty))
                .ReverseMap();

            CreateMap<ApplicationRole, ReadRoleDTO>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ReverseMap();

            CreateMap<Employee, ReadEmployeeDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.User != null ? src.User.UserName : string.Empty))
                .ForMember(dest => dest.Email,
                           opt => opt.MapFrom(src => src.User != null ? src.User.Email : string.Empty))
                .ForMember(dest => dest.Branch,
                           opt => opt.MapFrom(src => src.Branch != null ? src.Branch.Name : string.Empty))
                .ForMember(dest => dest.PhoneNumber,
                           opt => opt.MapFrom(src => src.User != null ? src.User.PhoneNumber : string.Empty))
                .ReverseMap();

            CreateMap<Delivery, ReadDeliveryDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.User != null ? src.User.UserName : string.Empty))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ID))
                .ReverseMap();

            CreateMap<Order, ReadOrderReportDTO>()
                .ForMember(dest => dest.MerchantName,
                           opt => opt.MapFrom(src => src.Merchant != null ? src.Merchant.User.UserName : string.Empty))
                .ForMember(dest => dest.CompanyPersent,
                           opt => opt.MapFrom(src => src.Delivery != null ? src.Delivery.CompanyPercent : 0))
                .ForMember(dest => dest.PaidShippingPrice,
                           opt => opt.MapFrom(src => src.ShippingPrice))
                .ForMember(dest => dest.DID,
                           opt => opt.MapFrom(src => src.DeliveryId))
                .ForMember(dest => dest.city,
                           opt => opt.MapFrom(src => src.City != null ? src.City.Name : string.Empty))
                .ForMember(dest => dest.Governorate,
                           opt => opt.MapFrom(src => src.Governorate != null ? src.Governorate.Name : string.Empty))
                .ForMember(dest => dest.OrderDate,
                           opt => opt.MapFrom(src => src.OrderDate.ToString("O")))
                .ReverseMap();
        }
    }
}
