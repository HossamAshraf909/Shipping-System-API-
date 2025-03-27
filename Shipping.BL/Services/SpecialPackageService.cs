using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class SpecialPackageService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public SpecialPackageService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReadPackageDto>> GetAllAsync()
        {
            var packages = await _unitOfWork.SpecialPackage.GetAllAsync();
            return _mapper.Map<List<ReadPackageDto>>(packages);
        }

        public async Task<ReadPackageDto?> GetByIdAsync(int id)
        {
            var package = await _unitOfWork.SpecialPackage.GetByIdAsync(id);
            return package != null ? _mapper.Map<ReadPackageDto>(package) : null;
        }

        public async Task AddAsync(AddPackageDto packageDto)
        {
            var package = _mapper.Map<SpecialPackages>(packageDto);
            await _unitOfWork.SpecialPackage.AddAsync(package);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AddPackageDto packageDto)
        {
            var existingPackage = await _unitOfWork.SpecialPackage.GetByIdAsync(id);
            if (existingPackage == null) return;

            _mapper.Map(packageDto, existingPackage);
            await _unitOfWork.SpecialPackage.UpdateAsync(existingPackage);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
    {
            var package = await _unitOfWork.SpecialPackage.GetByIdAsync(id);
            if (package == null) return;

            await _unitOfWork.SpecialPackage.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

    }
}
