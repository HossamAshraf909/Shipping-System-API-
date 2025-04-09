using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Employee
{
    public class AddEmployeeDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public string PhoneNumber { get; set; }
        public string Branch { get; set; }
    }
}
