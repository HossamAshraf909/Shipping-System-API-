using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [Range(1, 100)]
        public int  Quntity { get; set; }
        [Required]
        [Range(1, 50)]
        public int  Weight { get; set; }
        public virtual ICollection<Order_Product> Order_Products { get; set; }= new List<Order_Product>();

    }
}
