using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MetadataController : ControllerBase
    {
        private readonly IActionDescriptorCollectionProvider _actionDescriptorProvider;

        public MetadataController(IActionDescriptorCollectionProvider actionDescriptorProvider)
        {
            _actionDescriptorProvider = actionDescriptorProvider;
        }

        [HttpGet("controllers")]
        public IActionResult GetControllers()
        {
            var controllers = _actionDescriptorProvider.ActionDescriptors.Items
                .OfType<ControllerActionDescriptor>()
                .Select(d => d.ControllerName)
                .Distinct()
                .OrderBy(name => name)
                .ToList();

            return Ok(controllers);
        }
    }
}
