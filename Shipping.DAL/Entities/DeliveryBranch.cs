using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class DeliveryBranch
    {
        [Key, Column(Order = 0)]
        public int BranchID { get; set; }

        [Key, Column(Order = 1)]
        public int DeliveryID { get; set; }

        public virtual Branches Branch { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
