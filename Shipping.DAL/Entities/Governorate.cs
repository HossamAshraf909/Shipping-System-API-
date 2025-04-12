using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Governorate : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        public virtual List<City> cities { get; set; }

        public virtual ICollection<Order> orders { get; set; } = new List<Order>();

        public virtual ICollection<SpecialPackages> specialPackages { get; set; } = new List<SpecialPackages>();  
        public virtual ICollection<Merchant> Merchants { get; set; } = new List<Merchant>();
        public virtual ICollection<Delivery> deliveries { get; set; } = new List<Delivery>();

    }
}
