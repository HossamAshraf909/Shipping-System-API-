using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.City;
using Shipping.BL.DTOs.Governorate;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;
using Shipping.PL.DTOs.Governorate;

namespace Shipping.BL.Services
{
    public class GovernorateService
    {
        IMapper map;
        UnitOfWork unit;
        public GovernorateService(IMapper map, UnitOfWork unit)
        {
            this.map = map;
            this.unit = unit;

        }

        public List<ReadGovernorateDTO> GettAll()
        {
            List<Governorate> governorates = unit.GovRep.GetAll().ToList();
            List<ReadGovernorateDTO> governorateDTO = map.Map<List<ReadGovernorateDTO>>(governorates);
            return governorateDTO;
        }


        public ReadGovernorateDTO GetById(int id)
        {
            Governorate governorate = unit.GovRep.GetById(id);
            ReadGovernorateDTO governorateDTO = map.Map<ReadGovernorateDTO>(governorate);
            return governorateDTO;
        }


        public void Add (AddGovernorateDTO governorateDTO)
        {
            Governorate governorate = map.Map<Governorate>(governorateDTO);
            unit.GovRep.Add(governorate);
            unit.Save();
        }


        public void Update(AddGovernorateDTO governorateDTO)
        {
            Governorate governorate = map.Map<Governorate>(governorateDTO);
            unit.GovRep.Update(governorate);
            unit.Save();
        }


        public void Delete(int id)
        {
            Governorate governorate = unit.GovRep.GetById(id);
            governorate.IsDeleted = true;
            unit.Save();
        }



    }
}
