﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DAL.Entities;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.DTOs.Governorate;
using Shipping.BL.DTOs.Product;
using Shipping.BL.DTOs.ShippingType;
using Shipping.BL.DTOs.Weight;
using Shipping.PL.DTOs.Governorate;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.BL.DTOs.Village;
using Shipping.BL.DTOs.Order;




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

            CreateMap<Product, ReadProductDTO>().ReverseMap();
            CreateMap<SpecialPackages, ReadPackageDto>().ReverseMap();
            CreateMap<SpecialPackages, AddPackageDto>().ReverseMap();
            CreateMap<VillageDelivery, ReadVillageDTO>().ReverseMap();
            CreateMap<VillageDelivery, AddVillageDTO>().ReverseMap();
            CreateMap<OrderDTO ,Order>().ReverseMap();
        }

    }
}
