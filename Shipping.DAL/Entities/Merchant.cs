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
    public class Merchant:BaseEntity
    {
        [Key]
        public int ID { get; set; }

        public decimal PickUpPrice { get; set; }
        public decimal RejectedOrderPrice { get; set; }
        [ForeignKey("City")]
        public int cityId { get; set; }
        [ForeignKey("Governorate")]

        public int governrateId { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }

        public virtual ApplicationUser User { get; set; }

        // Navigation to branches (many-to-many)
        public virtual ICollection<MerchantBranch> MerchantBranches { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual City City { get; set; }
        public virtual Governorate Governorate  { get; set; }
        public virtual IEnumerable<SpecialPackages>? SpecialPackages { get; set; } = new List<SpecialPackages>();
    }
}
