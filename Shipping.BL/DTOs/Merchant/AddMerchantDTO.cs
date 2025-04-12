using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.BL.DTOs.SpecialPackage;

namespace Shipping.BL.DTOs.Merchant
{
    public class AddMerchantDTO
    {
        public decimal PickUpPrice { get; set; }
        public decimal RejectedOrderPrice { get; set; }
        public int CityId { get; set; }
        public int GovernorateId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
        public string Address { get; set; }
        public List<AddSpecialPackageDTO> specialPackages { get; set; } = new List<AddSpecialPackageDTO>(); 

    }

}
