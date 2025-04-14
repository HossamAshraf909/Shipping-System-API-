using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.Branch;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class BranchService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BranchService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ReadBranchDTO>> GetAllAsync()
        {
            var branches = await _unitOfWork.Branches.GetAllAsync();
            return _mapper.Map<List<ReadBranchDTO>>(branches);
        }

        public async Task<ReadBranchDTO?> GetByIdAsync(int id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            return branch != null ? _mapper.Map<ReadBranchDTO>(branch) : null;
        }

        public async Task AddAsync(AddBrachDTO branchDTO)
        {
            var branch = _mapper.Map<Branches>(branchDTO);
            await _unitOfWork.Branches.AddAsync(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, AddBrachDTO branchDTO)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null) return;

            _mapper.Map(branchDTO, branch);
            await _unitOfWork.Branches.UpdateAsync(branch);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(id);
            if (branch == null) return;
            branch.IsDeleted = true;
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task <IEnumerable<Branches>> SearchAsync(string Searchword)
        {
            var Branches= await _unitOfWork.Branches.SearchAsync(B => B.Name.Contains(Searchword));
            return Branches;
        }
        public async Task<PaginatedBranchesDTO> GetPaginatedAsync(int page, int pageSize)
        {
            var PaginatedBranches = new PaginatedBranchesDTO();
            var branches= await _unitOfWork.Branches.GetPaginatedAsync(page, pageSize);
            PaginatedBranches.BranchDTOs = _mapper.Map<List<ReadBranchDTO>>(branches.Data);
            PaginatedBranches.TotalRecords = branches.TotalRecords;
            PaginatedBranches.TotalPages = branches.TotalPages;
            return PaginatedBranches;
        }


    }
}
