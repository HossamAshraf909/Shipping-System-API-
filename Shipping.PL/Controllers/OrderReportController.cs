using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.Services;

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
       
        [HttpGet("{Status:alpha}")]
        public async Task<IActionResult> GetOrderByStatus(string Status)
        {
            var order = await OrderReportService.GetOrderByStatus(Status);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        
        [HttpGet("{FromDate:datetime}/{ToDate:datetime}")]
        public async Task<IActionResult> GetOrderByDate(DateTime FromDate, DateTime ToDate)
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
