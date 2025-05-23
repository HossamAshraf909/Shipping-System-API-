﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Branches:BaseEntity
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string Name { get; set; } = null!;
        [Column(TypeName ="date")]
        public DateTime Date { get; set; }
        public virtual ICollection<MerchantBranch> MerchantBranches { get; set; }
        public virtual ICollection<DeliveryBranch> DeliveryBranches { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
