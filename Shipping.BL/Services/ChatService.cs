using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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
        private readonly HttpClient _httpClient;

        public ChatService(string apiKey)
        {
            _apiKey = apiKey;
            _httpClient = new HttpClient();
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

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"OpenAI API error: {response.StatusCode} - {responseString}");
            }

            try
            {
                using var doc = JsonDocument.Parse(responseString);

                if (doc.RootElement.TryGetProperty("choices", out var choices) &&
                    choices.GetArrayLength() > 0 &&
                    choices[0].TryGetProperty("message", out var messageObj) &&
                    messageObj.TryGetProperty("content", out var contentProp))
                {
                    var reply = contentProp.GetString();
                    return new ChatResponse { Reply = reply };
                }
                else
                {
                    throw new Exception("Unexpected response structure from OpenAI API.");
                }
            }
            catch (JsonException je)
            {
                throw new Exception("Failed to parse response from OpenAI API.", je);
            }
        }
        public async Task<string> GetChatResponseAsync(string message)
        {
            var requestBody = new
            {
                model = "gpt-4o-mini",
                messages = new[] { new { role = "user", content = message } }
            };

            var content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiKey);

            var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);

            if (!response.IsSuccessStatusCode)
            {
                return "Error calling OpenAI API";
            }

            var responseBody = await response.Content.ReadAsStringAsync();
            using var jsonDoc = JsonDocument.Parse(responseBody);
            return jsonDoc.RootElement.GetProperty("choices")[0].GetProperty("message").GetProperty("content").GetString();
        }
    }
}
