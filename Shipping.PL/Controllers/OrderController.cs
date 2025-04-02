using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.product;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(OrderService orderService,ProductService productService, OrderProductService orderProductService)
        {
            OrderService = orderService;
            ProductService = productService;
            OrderProductService = orderProductService;
        }

        public OrderService OrderService { get; }
        public ProductService ProductService { get; }
        public OrderProductService OrderProductService { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await OrderService.GetAllOrdersAsync());
        }
        [HttpGet("{search:alpha}")]
        public async Task<IActionResult> GetOrderBystatus(string search)
        {
            var orders = await OrderService.GetOrderByStatusAsync(search);
            if (!orders.Any()) return NotFound("No orders found");
            return Ok(orders);
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDTO orderDTO)
        {
            if (orderDTO == null) BadRequest();
            if (!ModelState.IsValid) BadRequest(ModelState);
            var products = orderDTO.Products;
            foreach (var product in products)
            {
                await ProductService.AddProductAsync(product);
            }
            await OrderService.AddOrderAsync(orderDTO);

            return Ok();
        }
        [HttpPut("product-Edit")]
        public async Task<IActionResult> UpdateProduct(EditProductDTO productDTO)
        {
            if (productDTO == null) BadRequest();
            if (!ModelState.IsValid) BadRequest(ModelState);
            await ProductService.UpdateProductAsync(productDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if (id == 0) BadRequest();
            await ProductService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
