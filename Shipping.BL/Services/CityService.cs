using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.City;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class CityService
    {
        IMapper map;
        UnitOfWork unit;
        public CityService(IMapper map , UnitOfWork unit)
        {
            this.map = map;
            this.unit = unit;
            
        }

        public List<ReadCityDTO> GetAll()
        {
            List <City> cities = unit.CityRep.GetAll().ToList();
            List<ReadCityDTO> citesDTO = map.Map<List<ReadCityDTO>>(cities);  
            return citesDTO;
        
        }

        public ReadCityDTO GetById(int id)
        {
            City city = unit.CityRep.GetById(id);
            ReadCityDTO cityDTO = map.Map<ReadCityDTO>(city);
            return cityDTO;

        }

        public void Add(AddCityDTO cityDTO)
        {
            City city = map.Map<City>(cityDTO);
            unit.CityRep.Add(city);
        }

        public void Update(AddCityDTO cityDTO)
        {
            City city = map.Map<City>(cityDTO);
            unit.CityRep.Update(city);
        }

        public void Delete(int id)
        {
            City city = unit.CityRep.GetById(id);
            city.IsDeleted = true;
        }

    }
}
