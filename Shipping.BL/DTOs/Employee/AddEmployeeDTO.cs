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
        public string Password { get; set; }
        public string address { get; set; }
        public string UserRole { get; set; }
        public string PhoneNumber { get; set; }
        public string Branch { get; set; }
        public int UserId { get; set; }
    }
}
