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
    public class Merchant
    {
        [Key]
        public int ID { get; set; }

        public decimal PickUpPrice { get; set; }
        public decimal RejectedOrderPrice { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        // Navigation to branches (many-to-many)
        public virtual ICollection<MerchantBranch> MerchantBranches { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

    }
}
