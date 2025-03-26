using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositries;

namespace Shipping.DAL.UnitOfWork
{
    public class UnitOfWork
    {
        private readonly ShippingContext context;
        private  ProductRepositry _ProductRepositry; 

        public UnitOfWork(ShippingContext context)
        {
            this.context = context;
        }
        public ProductRepositry ProductRepositry
        {
            get
            {
                if (_ProductRepositry == null)
                    _ProductRepositry = new ProductRepositry(context);
                return _ProductRepositry;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
    }
}
