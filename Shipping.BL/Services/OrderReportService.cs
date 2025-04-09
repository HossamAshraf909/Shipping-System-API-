using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Shipping.BL.DTOs.OrderReport;

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
        public async Task<List<ReadOrderReportDTO>> GetAllOrders()
        {
            var orders = await unit.Orders.GetAllAsync();
            var orderReports = mapper.Map<List<ReadOrderReportDTO>>(orders);
            return orderReports;
        }
        public async Task<ReadOrderReportDTO> GetOrderByStatus(string status)
        {
            var order = await unit.Orders.GetOrderByStatusAsync(status);
            if (order == null)
            {
                return null;                
            }
            var orderReport = mapper.Map<ReadOrderReportDTO>(order);
            return orderReport;
        }
        public async Task<ReadOrderReportDTO> GetOrderByDate(DateTime Fromdate , DateTime ToDate)
        {
            var order = await unit.Orders.GetOrderByDateAsync(Fromdate, ToDate);
            if (order == null)
            {
                return null;
            }
            var orderReport = mapper.Map<ReadOrderReportDTO>(order);
            return orderReport;
        }
    }
}
