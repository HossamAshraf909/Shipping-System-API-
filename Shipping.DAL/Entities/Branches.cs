using System;
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
       
        [MaxLength(50),Required]
        public string Name { get; set; }
        [Column(TypeName ="date")]
        public DateTime Date { get; set; }

    }
}
