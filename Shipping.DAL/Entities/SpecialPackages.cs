using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class SpecialPackages
    {
        public int Id { get; set; }
       
        [ForeignKey("merchant")]
        public int merchantID { get; set; }

        [ForeignKey("city")]
        public int cityID { get; set; }
        [ForeignKey("governorate")]
        public int governorateID { get; set; }
        
        public decimal ShippingPrice { get; set; }  

        public virtual City city { get; set; }

        public virtual Governorate governorate { get; set; } 
        
        public virtual Merchant merchant { get; set; }

    }
}
