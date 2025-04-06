using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Weight;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class WeightPriceService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _map;

        public WeightPriceService(IUnitOfWork unit, IMapper map)
        {
            _unit = unit;
            _map = map;
        }

        public async Task<List<ReadWeightDTO>> GetAllAsync()
        {
            var weightPrices = await _unit.WeightPrices.GetAllAsync();
            return _map.Map<List<ReadWeightDTO>>(weightPrices);
        }

        public async Task<ReadWeightDTO?> GetByIdAsync(int id)
        {
            var weightPrice = await _unit.WeightPrices.GetByIdAsync(id);
            return weightPrice == null ? null : _map.Map<ReadWeightDTO>(weightPrice);
        }


        public async Task AddAsync(AddWeightDTO weightDTO)
        {
            var weightPrice = _map.Map<WeightPrice>(weightDTO);
            await _unit.WeightPrices.AddAsync(weightPrice);
            await _unit.SaveChangesAsync();
        }

        public async Task UpdateAsync(AddWeightDTO weightDTO)
        {
            var existingWeightPrice = await _unit.WeightPrices.GetByIdAsync(weightDTO.Id);
            if (existingWeightPrice == null) return;
          _map.Map(weightDTO, existingWeightPrice);
            
            await _unit.WeightPrices.UpdateAsync(existingWeightPrice);
            await _unit.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var weightPrice = await _unit.WeightPrices.GetByIdAsync(id);
             if (weightPrice == null) return;

            weightPrice.IsDeleted = true;
            await _unit.SaveChangesAsync();
        }
    }
}
