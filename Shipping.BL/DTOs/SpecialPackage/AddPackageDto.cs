using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.SpecialPackage
{
    public class AddPackageDto
    {
        public int cityID { get; set; }
        public int governorateID { get; set; }
        public decimal ShippingPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
