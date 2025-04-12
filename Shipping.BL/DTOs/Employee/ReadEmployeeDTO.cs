using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Employee
{
    public class ReadEmployeeDTO
    {
        public int id {  get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string UserRole { get; set; }
        public string PhoneNumber { get; set; }
        public string Branch { get; set; }
        public string UserId { get; set; }

    }
}
