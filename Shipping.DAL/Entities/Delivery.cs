using Shipping.DAL.Entities.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Delivery
    {

        [Key]
        public int ID { get; set; }

        public string TypeOfDiscount { get; set; }
        public float CompanyPercent { get; set; }
        [Required ,MaxLength(50)]
        public string Branch { get; set; }
        [Required, MaxLength(50)]
        public string Governorate { get; set; }
        [Required, MaxLength(50)]
        public string PhoneNumber { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        public virtual ICollection<Order> Orders { get; set; }

        public virtual ICollection<DeliveryBranch> DeliveryBranches { get; set; }






        
        
    }
}
