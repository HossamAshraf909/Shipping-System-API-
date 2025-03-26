using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs.Product;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public ProductController(ProductService productService, OrderProductService orderProductService)
        {
            ProductService = productService;
            OrderProductService = orderProductService;
        }

        public ProductService ProductService { get; }
        public OrderProductService OrderProductService { get; }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDTO productDTO)
        {
            if (productDTO == null) BadRequest();
            if(!ModelState.IsValid) return BadRequest(ModelState);
            ProductService.AddProduct(productDTO);
            return Ok();
        }
    }
}
