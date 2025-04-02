using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Shipping.BL.Services
{
    public class OrderReportService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public OrderReportService(IUnitOfWork unit , IMapper mapper)
        {
            this.unit = unit;
            this.mapper = mapper;
        }
        
    }
}
