using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Governorate;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;
using Shipping.PL.DTOs.Governorate;

namespace Shipping.BL.Services
{
    public class GovernorateService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public GovernorateService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReadGovernorateDTO>> GetAllAsync()
        {
            var governorates = await _unitOfWork.Governorates.GetAllAsync();
            return _mapper.Map<List<ReadGovernorateDTO>>(governorates);
        }

        public async Task<ReadGovernorateDTO?> GetByIdAsync(int id)
        {
            var governorate = await _unitOfWork.Governorates.GetByIdAsync(id);
            return governorate != null ? _mapper.Map<ReadGovernorateDTO>(governorate) : null;
        }

        public async Task AddAsync(AddGovernorateDTO governorateDTO)
        {
            var governorate = _mapper.Map<Governorate>(governorateDTO);
            await _unitOfWork.Governorates.AddAsync(governorate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AddGovernorateDTO governorateDTO)
        {
            var governorate = await _unitOfWork.Governorates.GetByIdAsync(id);
            if (governorate == null) return;

            _mapper.Map(governorateDTO, governorate);
            await _unitOfWork.Governorates.UpdateAsync(governorate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var governorate = await _unitOfWork.Governorates.GetByIdAsync(id);
            if (governorate == null) return;

            governorate.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
        }



    }
}
