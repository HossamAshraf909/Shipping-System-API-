using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DAL.Persistent.UnitOfWork;

namespace Shipping.BL.Services
{
    public class OrderProductService
    {

        private readonly IUnitOfWork unit;
        private readonly IMapper map;

        public OrderProductService(IUnitOfWork unit ,IMapper map)

        {
            this.unit = unit;
            this.map = map;
        }


    }
}
