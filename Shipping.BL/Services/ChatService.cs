using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Shipping.BL.DTOs;

namespace Shipping.BL.Services
{
    public class ChatService
    {
        private readonly string _apiKey;

        public ChatService(string apiKey)
        {
            _apiKey = apiKey;
        }

        public async Task<ChatResponse> SendMessageAsync(string message)
        {
            using var client = new HttpClient();

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var requestBody = new
            {
                model = "gpt-4o",
                messages = new[]
                {
                    new { role = "user", content = message }
                }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);
            var responseString = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseString);
            var reply = doc.RootElement
                .GetProperty("choices")[0]
                .GetProperty("message")
                .GetProperty("content")
                .GetString();

            return new ChatResponse { Reply = reply };

        }

    }
}
