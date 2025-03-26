using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.ShippingType;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class ShippingTypeService
    {
        private readonly UnitOfWork _unit;
        private readonly IMapper _map;

        public ShippingTypeService(UnitOfWork unit , IMapper map)
        {
            this._unit = unit;
            this._map = map;
        }
        public IEnumerable<ReadShippingTypeDTO> GetAll()
        {
            return _map.Map<IEnumerable<ReadShippingTypeDTO>>(_unit.shippingTypeRepositry.GetAll());
        }
        public void Add(AddShippingTypeDTO shippingTypeDTO) 
        {
            _unit.shippingTypeRepositry.Add(_map.Map<ShippingType>(shippingTypeDTO));
            _unit.Save();
        }
        public void Edit(AddShippingTypeDTO shippingTypeDTO)
        {
            _unit.shippingTypeRepositry.Update(_map.Map<ShippingType>(shippingTypeDTO));
            _unit.Save();
        }
        public void Delete(AddShippingTypeDTO shippingTypeDTO)
        {
             _unit.shippingTypeRepositry.Delete(_map.Map<ShippingType>(shippingTypeDTO));
             _unit.Save();
        }
    }
}
