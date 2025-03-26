using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Product;



namespace Shipping.BL.Mappers
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            //productMap
            CreateMap<CreateProductDTO,Product>().ReverseMap();
        }
    }
}
