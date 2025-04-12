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
    public class Employee
    {

        [Key]
        public int ID { get; set; }
        [Required,MaxLength(20)]
        public string PhoneNumber { get; set; }
        [ForeignKey("Branch")]
        public int BranchId { get; set; }
       
        [Required]
        [ForeignKey("User")]
        public string UserID { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual Branches Branch { get; set; }
    }
}
