using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.SpecialPackage
{
    public class ReadPackageDto
    {
        public int Id { get; set; }
        public int cityID { get; set; }
        public int governorateID { get; set; }

        public decimal ShippingPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
