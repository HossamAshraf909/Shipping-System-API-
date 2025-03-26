using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositries;
using Shipping.DAL.Entities;
using Shipping.DAL.Persistent.Data.Context;
using Shipping.DAL.Persistent.Repositries;

namespace Shipping.DAL.UnitOfWork
{
    public class UnitOfWork
    {

        private readonly ShippingContext context;
        private ProductRepositry _ProductRepositry;
        private OrderProductRepositry _OrderProductRepositry;
        private GenericRepositry<City> cityRep;
        private GenericRepositry<Governorate> govRep;
        private GenericRepositry<Branches> branchRep;
        private GenericRepositry<ShippingType> _ShippingTypeRepositry;
        public UnitOfWork( ShippingContext context)
        {
            this.context = context;
        }

        public GenericRepositry<City> CityRep
        {
            get
            {
                if (cityRep == null)
                    cityRep = new GenericRepositry<City>(context);
                return cityRep;

            }
        }

        public GenericRepositry<Governorate> GovRep
        {
            get
            {
                if (govRep == null)
                    govRep = new GenericRepositry<Governorate>(context);
                return govRep;

            }
        }

        public GenericRepositry<Branches> BranchRep
        {
            get
            {
                if (branchRep == null)
                    branchRep = new GenericRepositry<Branches>(context);
                return branchRep;

            }
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

        public OrderProductRepositry orderProductRepositry
        {
            get
            {
                if (_OrderProductRepositry == null)
                    _OrderProductRepositry = new(context);
                return _OrderProductRepositry;
            }
        }

        public GenericRepositry<ShippingType> shippingTypeRepositry
        {
            get
            {
                if (_ShippingTypeRepositry == null)
                    _ShippingTypeRepositry = new(context);
                return _ShippingTypeRepositry;
            }
        }
        

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
