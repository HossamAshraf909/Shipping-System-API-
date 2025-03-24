﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Governorate : BaseEntity
    {

        [Required, MaxLength(50)]
        public string Name { get; set; } = null!;

        public virtual List<City> cities { get; set; }

        public ICollection<Order> orders { get; set; } = new List<Order>();

    }
}
