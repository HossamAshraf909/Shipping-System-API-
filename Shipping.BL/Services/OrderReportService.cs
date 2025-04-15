using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.OrderReport;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.BL.Services
{
    public class OrderReportService
    {
        private readonly IUnitOfWork unit;
        private readonly IMapper mapper;

        public OrderReportService(IUnitOfWork unit, IMapper mapper)
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
        public async Task<PaginatedOrderReportDTO> GetPaginatedOrderReport(int pageSize, int pageNumber)
        {
            var paginatedReportDto = new PaginatedOrderReportDTO();
            var Report =  await unit.Orders.GetPaginatedAsync(pageNumber, pageSize);
            paginatedReportDto.TotalRecords=Report.TotalRecords;
            paginatedReportDto.TotalPages=Report.TotalPages;
            paginatedReportDto.Orders= mapper.Map<List<ReadOrderReportDTO>>(Report.Data);
            return paginatedReportDto;
        }
        public async Task<PaginatedOrderReportDTO> GetOrderByStatus(OrderStatus status , int pageNumber,int pageSize)
        {
            var orders = await unit.Orders.GetOrderByStatusAsync(status);
            if (orders == null)
            {
                return null;
            }
            var paginatedOrders = new PaginatedOrderReportDTO();
            paginatedOrders.TotalRecords = orders.Count();
            paginatedOrders.TotalPages = (int)Math.Ceiling((double)paginatedOrders.TotalRecords / pageSize);
            paginatedOrders.Orders = mapper.Map<List<ReadOrderReportDTO>>(orders);
            paginatedOrders.Orders = paginatedOrders.Orders.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return paginatedOrders;
        }
        public async Task<List<ReadOrderReportDTO>> GetOrderByDate(DateTime Fromdate, DateTime ToDate)
        {
            var order = await unit.Orders.GetOrderByDateAsync(Fromdate, ToDate);
            if (order == null)
            {
                return null;
            }
            var orderReport = mapper.Map<List<ReadOrderReportDTO>>(order);
            return orderReport;
        }
    }
}
