using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Data.Context;

namespace Shipping.DAL.Persistent.Repositries
{
    public class ProductRepositry : GenericRepositry<Product>
    {
        public ProductRepositry(ShippingContext context) : base(context)
        {
        }
        public void deleteProduct(int id)
        {
            var product = GetById(id);
            context.Products.Remove(product);
        }

    }
}
