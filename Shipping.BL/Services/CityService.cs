using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.City;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class CityService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public CityService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReadCityDTO>> GetAllAsync()
        {
            var cities = await _unitOfWork.Cities.GetAllAsync();
            return _mapper.Map<List<ReadCityDTO>>(cities);
        }

        public async Task<ReadCityDTO?> GetByIdAsync(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            return city != null ? _mapper.Map<ReadCityDTO>(city) : null;
        }

        public async Task AddAsync(AddCityDTO cityDTO)
        {
            var city = _mapper.Map<City>(cityDTO);
            await _unitOfWork.Cities.AddAsync(city);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AddCityDTO cityDTO)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null) return;

            _mapper.Map(cityDTO, city);
            await _unitOfWork.Cities.UpdateAsync(city);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _unitOfWork.Cities.GetByIdAsync(id);
            if (city == null) return;
            city.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<List<ReadCityDTO>> Search(string Searchword)
        {
            var cities = await _unitOfWork.Cities.SearchAsync(g => g.Name.Contains(Searchword));
            return _mapper.Map<List<ReadCityDTO>>(cities);
        }
    }
}
