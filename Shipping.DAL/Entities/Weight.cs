using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shipping.DAL.Entities
{
    public class Weight:BaseEntity
    {
        [DataType(DataType.Currency)]
        public decimal DefaultPrice { get; set; }

        public int DefaultWeight { get; set; }

        public decimal ExtraPricePerKilo { get; set; }







    }
}
