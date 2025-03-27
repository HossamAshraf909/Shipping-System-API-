using AutoMapper;
using Shipping.BL.DTOs.SpecialPackage;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.Services
{
    public class SpecialPackageService
    {
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
    }
}
