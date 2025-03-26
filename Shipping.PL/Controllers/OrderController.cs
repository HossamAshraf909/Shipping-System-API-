using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Product;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(ProductService productService, OrderProductService orderProductService)
        {
            ProductService = productService;
            OrderProductService = orderProductService;
        }

        public ProductService ProductService { get; }
        public OrderProductService OrderProductService { get; }

        

        [HttpPost("product")]
        public IActionResult AddProduct(CreateProductDTO productDTO)
        {
            if (productDTO == null) BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ProductService.AddProduct(productDTO);
            return Ok();
        }
        [HttpPut("product-Edit")]
        public IActionResult UpdateProduct(EditProductDTO productDTO)
        {
            if (productDTO == null) BadRequest();
            if (!ModelState.IsValid) return BadRequest(ModelState);
            ProductService.UpdateProduct(productDTO);
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id == 0) BadRequest();
            ProductService.DeleteProduct(id);
            return Ok();
        }
    }
}
