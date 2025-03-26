using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Data.Context;

namespace Shipping.DAL.Persistent.Repositries
{
    public class OrderProductRepositry : GenericRepositry<Order_Product>
    {
        public OrderProductRepositry(ShippingContext context) : base(context)
        {

        }
         
        public void deleteProductFromOrder(int id)
        {
            var Order_Product = GetById(id);
            context.OrderProducts.Remove(Order_Product);
            context.Products.Remove(Order_Product.Product);
        }
        
    }
}
