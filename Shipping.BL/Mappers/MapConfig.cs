
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DAL.Entities;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.DTOs.Governorate;
using Shipping.BL.DTOs.ShippingType;
using Shipping.BL.DTOs.Weight;

using Shipping.BL.DTOs.SpecialPackage;
using Shipping.PL.DTOs.Governorate;
using Shipping.BL.DTOs.Village;
using Shipping.BL.DTOs.Order;

using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Shipping.BL.DTOs.product;
using System.Net;
using Shipping.BL.DTOs.OrderReport;
using Shipping.DAL.Entities.Identity;
using Shipping.BL.DTOs.Auth.Role;
using Shipping.BL.DTOs.Employee;
using Shipping.BL.DTOs.Delivery;





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
            CreateMap<AddShippingTypeDTO, ShippingType>().ReverseMap();
            CreateMap<ShippingType, ReadShippingTypeDTO>().ReverseMap();
            CreateMap<WeightPrice, ReadWeightDTO>().ReverseMap();
            CreateMap<WeightPrice, AddWeightDTO>().ReverseMap();

            CreateMap<CreateProductDTO, Product>().ReverseMap();
            CreateMap<SpecialPackages, ReadPackageDto>().ReverseMap();
            CreateMap<SpecialPackages, AddPackageDto>().ReverseMap();
            CreateMap<VillageDelivery, ReadVillageDTO>().ReverseMap();
            CreateMap<VillageDelivery, AddVillageDTO>().ReverseMap();

            CreateMap<Product, ReadProductDTO>().ReverseMap();
            CreateMap<SpecialPackages, ReadPackageDto>().ReverseMap();
            CreateMap<SpecialPackages, AddPackageDto>().ReverseMap();
            CreateMap<VillageDelivery, ReadVillageDTO>().ReverseMap();
            CreateMap<VillageDelivery, AddVillageDTO>().ReverseMap();


            CreateMap<AddOrderDTO, Order>().AfterMap((src, dist) =>
            {
                dist.TotalWeight = src.Products.Sum(p => p.Weight * p.Quantity);
                dist.MerchantId = src.MerchentId;

                if (src.IsVillageDelivery == true)

                {
                    dist.VillageStreetAddress = src.VillageStreetAddress;
                }

            }).ReverseMap();
            CreateMap<Order, ReadOrderDTO>().AfterMap((src, dist) =>
            {
                dist.Governorate = src.Governorate.Name;
                dist.City = src.City.Name;
                dist.merchntName = src.Merchant?.User.UserName;
                dist.BranchName = src.Branch?.Name;
            }).ReverseMap();
            CreateMap<Order, ReadOrderWithProducts>().AfterMap((src, dist) =>
            {
                foreach (var product in src.OrderProducts)
                {
                    dist.Products.Add(new EditProductDTO
                    {
                        Id = product.ProductId,
                        Name = product.Product.Name,
                        Quantity = product.Product.Quantity,
                        Weight = product.Product.Weight,
                    });
                }
                dist.merchantId = src.Merchant?.ID;
            }).ReverseMap();
            CreateMap<Order, EditOrderDTO>().AfterMap((src, dist) =>
            {
                dist.TotalWeight = src.TotalWeight;
                dist.MerchentId = src.MerchantId;
                dist.branchId = src.BranchId;
                dist.CityId = src.CityId;
                dist.GovernorateId = src.GovernorateId;
                dist.ShippingTypeId = src.ShippingTypeId;
                dist.IsVillageDelivery = src.IsVillageDelivery;
                if (src.IsVillageDelivery == true)
                {
                    dist.VillageStreetAddress = src.VillageStreetAddress;
                }
                dist.orderStatus = src.orderStatus;
                foreach (var product in src.OrderProducts)
                {
                    dist.Products.Add(new EditProductDTO
                    {
                        Id = product.ProductId,
                        Name = product.Product.Name,
                        Quantity = product.Product.Quantity,
                        Weight = product.Product.Weight,
                    });
                }

            }).ReverseMap();
            CreateMap<ApplicationRole, ReadRoleDTO>().AfterMap((dist, src) =>
            {
                dist.Id = src.Id;
            }).ReverseMap();


            CreateMap<Employee, ReadEmployeeDTO>().AfterMap(async (src, dist) =>
            {
                dist.Name = src.User.UserName;
                dist.Email = src.User.Email;
                dist.Branch = src.Branch.Name;
            }).ReverseMap();
            CreateMap<Delivery, ReadDeliveryDTO>().AfterMap((src, dist) =>
            {
                dist.Name = src.User.UserName;
                dist.Id = src.ID;
            }).ReverseMap();
            CreateMap<Order, ReadOrderReportDTO>()
      .ForMember(dest => dest.MerchantName,
                 opt => opt.MapFrom(src => src.Merchant.User.UserName))

      .ForMember(dest => dest.CompanyPersent,
                 opt => opt.MapFrom(src => src.Delivery.CompanyPercent))

      .ForMember(dest => dest.PaidShippingPrice,
                 opt => opt.MapFrom(src => src.ShippingPrice))

      .ForMember(dest => dest.DID,
                 opt => opt.MapFrom(src => src.DeliveryId))

      .ForMember(dest => dest.TotalCoast,
                 opt => opt.MapFrom(src =>
                      (src.Delivery.CompanyPercent) == 0
                          ? src.OrderPrice
                          : ((decimal)(src.Delivery.CompanyPercent) * src.ShippingPrice) + src.OrderPrice
                 ))

      .ForMember(dest => dest.city,
                 opt => opt.MapFrom(src => src.City.Name))

      .ForMember(dest => dest.Governorate,
                 opt => opt.MapFrom(src => src.Governorate.Name))

      .ForMember(dest => dest.OrderDate,
                 opt => opt.MapFrom(src => src.OrderDate.ToString("O")));

        }
    }
}
