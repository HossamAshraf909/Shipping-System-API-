using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Delivery
{
    public class AddDeliveryDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<int> BranchesId { get; set; }
        public int GovernorateId { get; set; }
        public string PhoneNumber { get; set; }
        public string address { get; set; }
        public string TypeOfDiscount { get; set; }
        public float CompanyPercent { get; set; }
    }
}
