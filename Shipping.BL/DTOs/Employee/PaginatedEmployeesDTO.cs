using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.Branch;

namespace Shipping.BL.DTOs.Employee
{
    public class PaginatedEmployeesDTO
    {
        public int TotalRecords { get; set; }
        public int TotalPages { get; set; }
        public List<ReadEmployeeDTO> EmployeeDTOs { get; set; } = new();
    }
}
