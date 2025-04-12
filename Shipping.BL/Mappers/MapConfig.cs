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

using Shipping.PL.DTOs.Governorate;
using Shipping.BL.DTOs.SpecialPackage;
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
            CreateMap<SpecialPackages,ReadPackageDto>().ReverseMap();
            CreateMap<SpecialPackages,AddPackageDto>().ReverseMap();
            CreateMap<VillageDelivery,ReadVillageDTO>().ReverseMap();
            CreateMap<VillageDelivery,AddVillageDTO>().ReverseMap();

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
            CreateMap<Order, ReadOrderReportDTO>().AfterMap((src, dist) =>
            {
                dist.Governorate = src.Governorate.Name;
                dist.city = src.City.Name;
                dist.PaidShippingPrice = src.ShippingPrice;
                dist.OrderDate = src.OrderDate.ToString("O") ;  
            }).ReverseMap();
            CreateMap<ApplicationRole, ReadRoleDTO>().AfterMap((dist, src) =>
            {
                dist.Id = src.Id;
            }).ReverseMap();

            CreateMap<Employee, ReadEmployeeDTO>().AfterMap((src, dist) =>
            {
                dist.Name = src.User.UserName;
                dist.Email = src.User.Email;
            }).ReverseMap();
            CreateMap<Delivery , ReadDeliveryDTO >().AfterMap((src, dist) =>
            {
                dist.Name = src.User.UserName;
                dist.Id = src.ID;
            }).ReverseMap();
        }

    }
}
