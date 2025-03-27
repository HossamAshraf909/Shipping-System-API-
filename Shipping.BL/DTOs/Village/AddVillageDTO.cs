using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.VillageDelivery
{
    public class AddVillageDTO
    {
      
        public string VillageName { get; set; }  // اسم القرية
        public string CityName { get; set; }  // اسم المدينة
        public string GovernorateName { get; set; }  // اسم المحافظة
        public decimal Price { get; set; }
     
    }
}
