<<<<<<< HEAD
﻿using AutoMapper;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
=======

﻿using System.Collections.Generic;
>>>>>>> master
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class SpecialPackageService
    {
<<<<<<< HEAD
        IMapper mapper;
        UnitOfWork unitOfWork;
        public SpecialPackageService(IMapper mapper,UnitOfWork unitOfWork)
        {
                this.mapper = mapper;
                this.unitOfWork = unitOfWork;
        }
        public List<ReadPackageDto> GetAll()
        {
            List<SpecialPackages> packages = unitOfWork.specialPackage.GetAll().ToList();
            List<ReadPackageDto> packagesDTO = mapper.Map<List<ReadPackageDto>>(packages);
            return packagesDTO;
        }
        public ReadPackageDto GetById(int id)
        {
            SpecialPackages package = unitOfWork.specialPackage.GetById(id);
            ReadPackageDto packageDTO = mapper.Map<ReadPackageDto>(package);
            return packageDTO;
        }
        public void Add(AddPackageDto PackageDto)
        {
            SpecialPackages package = mapper.Map<SpecialPackages>(PackageDto);
            unitOfWork.specialPackage.Add(package);
            unitOfWork.Save();
        }
        public void Update(AddPackageDto packageDTO)
        {
            SpecialPackages package = mapper.Map<SpecialPackages>(packageDTO);
            unitOfWork.specialPackage.Update(package);
            unitOfWork.Save();
        }

        public void Delete(int id)
        {
            SpecialPackages package = unitOfWork.specialPackage.GetById(id);
            package.IsDeleted = true;
            unitOfWork.Save();
        }
=======
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


>>>>>>> master
    }
}
