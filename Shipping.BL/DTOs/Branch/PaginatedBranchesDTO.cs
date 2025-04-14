using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.Order;

namespace Shipping.BL.DTOs.Branch
{
    public class PaginatedBranchesDTO
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public List<ReadBranchDTO> BranchDTOs { get; set; } = new List<ReadBranchDTO>();
    }
}
