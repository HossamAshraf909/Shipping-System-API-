﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class City:BaseEntity
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
      

        [Column(TypeName ="money"),Required]
        public decimal ShippingPrice { get; set; }

        [Column(TypeName = "money"), Required]
        public decimal PickUpShippingPrice { get; set; }
      
        [ForeignKey("governorate")]
        public int GovId { get; set; }
        public virtual Governorate? governorate { get; set; }

        public ICollection<Order> orders { get; set; } = new List<Order>();


    }
}
