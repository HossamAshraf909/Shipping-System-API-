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
using Shipping.PL.DTOs.Governorate;
using AutoMapper;
using Shipping.BL.DTOs.Product;
using Shipping.BL.DTOs.Weight;



namespace Shipping.BL.Mappers
{
    public class MapConfig :Profile
    {
        public MapConfig()
        {
            CreateMap<City, ReadCityDTO>().ReverseMap();
            CreateMap<City, AddCityDTO>().ReverseMap();

            CreateMap<Governorate, AddGovernorateDTO>().ReverseMap();
            CreateMap<Governorate, ReadGovernorateDTO>().ReverseMap();

            CreateMap<Branches, AddBrachDTO>().ReverseMap();
            CreateMap<Branches, ReadBranchDTO>().ReverseMap();

            CreateMap<WeightPrice, ReadWeightDTO>().ReverseMap();
            CreateMap<WeightPrice, AddWeightDTO>().ReverseMap();


            //hossam
            CreateMap<CreateProductDTO, Product>().ReverseMap();


         
        }












    //public class MapConfig:Profile
    //{
    //    public MapConfig()
    //    {
    //        //productMap
    //        CreateMap<CreateProductDTO,Product>().ReverseMap();
    //    }







    }
}
