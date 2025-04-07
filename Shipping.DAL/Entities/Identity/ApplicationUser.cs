using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities.Identity
{
    public class ApplicationUser : IdentityUser
    {

        public string Address { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Merchant Merchant { get; set; }
        public virtual Delivery Delivery { get; set; }

    }
}
