using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.DAL.UnitOfWork;

namespace Shipping.BL.Services
{
    public class OrderProductService
    {
        private readonly UnitOfWork unit;
        private readonly IMapper map;

        public OrderProductService(UnitOfWork unit ,IMapper map)
        {
            this.unit = unit;
            this.map = map;
        }


    }
}
