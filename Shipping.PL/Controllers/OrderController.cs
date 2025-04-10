﻿using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Order;
using Shipping.BL.DTOs.product;
using Shipping.BL.Services;
using Shipping.DAL.Entities.Identity;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(OrderService orderService, ProductService productService, OrderProductService orderProductService ,UserManager<ApplicationUser> userManager)
        {
            OrderService = orderService;
            ProductService = productService;
            OrderProductService = orderProductService;
            UserManager = userManager;
        }

        public OrderService OrderService { get; }
        public ProductService ProductService { get; }
        public OrderProductService OrderProductService { get; }
        public UserManager<ApplicationUser> UserManager { get; }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(await OrderService.GetAllOrdersAsync());
        }
        [HttpGet("{search:alpha}")]
        public async Task<IActionResult> GetOrderBystatus(string search)
        {
            var orders = await OrderService.GetOrderByStatusAsync(search);
            if (!orders.Any()) return Ok(new
            {
                Data = orders,
                Message = "No orders found with the given status.",
            });
            return Ok(orders);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            if (id == 0) BadRequest();
            var order = await OrderService.GetOrderByIdAsync(id);
            if (order == null) return NotFound();
            return Ok(order);
        } 
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            if (id == 0) BadRequest();
            await OrderService.DeleteOrderAsync(id);
            return Ok();
        }
        [HttpPost]
        public async Task<IActionResult> AddOrder(AddOrderDTO orderDTO)
        {
            if (orderDTO == null) BadRequest();
            if (!ModelState.IsValid) BadRequest(ModelState);
            if (orderDTO.MerchentId == 0)
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var user = await UserManager.FindByIdAsync(userId);
                orderDTO.MerchentId = user.Merchant.ID;
            }
            await OrderService.AddOrderAsync(orderDTO);

            return Ok();
        }
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateOrder(int id, AddOrderDTO orderDTO)
        {
            if (orderDTO == null) BadRequest();
            if (!ModelState.IsValid) BadRequest(ModelState);
            await OrderService.UpdateOrderAsync(id, orderDTO);
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
        [HttpDelete("/product/{id:int}")]
        public async Task<IActionResult> DeleteProductAsync(int id)
        {
            if (id == 0) BadRequest();
            await ProductService.DeleteProductAsync(id);
            return Ok();
        }
    }
}
