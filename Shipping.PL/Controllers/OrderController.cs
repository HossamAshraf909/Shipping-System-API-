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
        public async Task<IActionResult> AddProduct(CreateProductDTO productDTO)
        {
            if (productDTO == null) BadRequest();
            if (!ModelState.IsValid)  BadRequest(ModelState);
            await ProductService.AddProductAsync(productDTO);
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
