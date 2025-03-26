using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Branch;
using Shipping.BL.DTOs.City;
using Shipping.DAL.Entities;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class BranchService
    {

        IMapper map;
        UnitOfWork unit;
        public BranchService(IMapper map, UnitOfWork unit)
        {
            this.map = map;
            this.unit = unit;

        }


        public List<ReadBranchDTO> GetAll()
        {
            List<Branches> branchs = unit.BranchRep.GetAll().ToList();
            List<ReadBranchDTO> branchsDTO = map.Map<List<ReadBranchDTO>>(branchs);
            return branchsDTO;
        }


        public ReadBranchDTO GetById (int id)
        {
            Branches branch = unit.BranchRep.GetById(id);
            ReadBranchDTO branchDTO = map.Map<ReadBranchDTO>(branch);
            return branchDTO;
        }

        public void Add(AddBrachDTO branchDTO)
        {
            Branches branch = map.Map<Branches>(branchDTO);
            unit.BranchRep.Add(branch);
            unit.Save();
        }



        public void Update(AddBrachDTO branchDTO)
        {
            Branches branch= map.Map<Branches>(branchDTO);
            unit.BranchRep.Update(branch);
            unit.Save();
        }



        public void Delete(int id)
        {
            Branches branch = unit.BranchRep.GetById(id);
            branch.IsDeleted = true;
            unit.Save();
        }

    }
}
