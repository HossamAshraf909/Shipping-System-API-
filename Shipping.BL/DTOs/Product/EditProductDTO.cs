using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.BL.DTOs.Product
{
    public class EditProductDTO
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; } = false;
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [Required]
        [Range(1, 100)]
        public int Quantity { get; set; }

        [Required]
        [Range(1, 100)]
        public int Weight { get; set; }
    }
}
