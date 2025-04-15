using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.Services;
using Shipping.DAL.Persistent.Enums;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  
    public class OrderReportController : ControllerBase
    {
        public OrderReportService OrderReportService { get; }
        public OrderReportController(OrderReportService orderReportService)
        {
            OrderReportService = orderReportService;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await OrderReportService.GetAllOrders();
            if (orders == null)
            {
                return NotFound();
            }
            return Ok(orders);
        }
        [HttpGet("Paginated")]
        public async Task<IActionResult> GetOrderReportPaginatedAsync(int pagesize=10 , int pageNumber=1)
        {
            var ordersReport =await OrderReportService.GetPaginatedOrderReport(pagesize, pageNumber);
            if (!ordersReport.Orders.Any())
                return Ok(new
                {
                    message= "No orders found",
                    data = ordersReport,
                });
            return Ok(ordersReport);
        }
       
        [HttpGet("{Status:alpha}")]
        public async Task<IActionResult> GetOrderByStatus(OrderStatus Status,int pageSize=10 , int PageNumber=1)
        {
            if (Status == OrderStatus.All) return Ok(await OrderReportService.GetPaginatedOrderReport(pageSize, PageNumber));
            var order = await OrderReportService.GetOrderByStatus(Status,PageNumber,pageSize);
            if (!order.Orders.Any())
                return Ok(new
                {
                    message = "No orders found",
                    data = order,
                });
            return Ok(order);
        }
        
        [HttpGet("{FromDate:datetime}/{ToDate:datetime}")]
        public async Task<IActionResult> GetOrderByDate(DateTime FromDate,DateTime ToDate)
        {
            var order = await OrderReportService.GetOrderByDate(FromDate, ToDate);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

    }
}
