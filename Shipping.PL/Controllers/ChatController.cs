using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shipping.BL.DTOs;
using Shipping.BL.Services;

namespace Shipping.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {

        private readonly ChatService _chatService;

        public ChatController(IConfiguration configuration)
        {
            var apiKey = configuration["OpenAI:ApiKey"];
            _chatService = new ChatService(apiKey);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ChatRequest request)
        {
            var response = await _chatService.SendMessageAsync(request.Message);
            return Ok(response);
        }

    }
}
