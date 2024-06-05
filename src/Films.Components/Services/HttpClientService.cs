using Films.Components.Interfaces;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Films.Components.Services
{
    public class HttpClientService<T> : IHttpClientService<T>
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private readonly string _baseUrl = "https://api.example.com";
        private ILogger<HttpClientService<T>> _logger;

        public HttpClientService(ILogger<HttpClientService<T>> logger) 
        {
            _logger = logger;
        }

        public async Task<T?> GetAsync(T item, string endpoint)
        {
            try
            {
                string url = $"{_baseUrl}/{endpoint}";
                HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);

                if (responseMessage != null)
                {
                    responseMessage.EnsureSuccessStatusCode();
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    string responseBody = await responseMessage.Content.ReadAsStringAsync();
                    var response = JsonConvert.DeserializeObject<T>(responseBody);

                    return response != null ? response : default;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return default;
            }

            return default;
        }

        public async Task<T?> PostAsync(T item, string endpoint)
        {
            try
            {
                string url = $"{_baseUrl}/{endpoint}";
                var content = new StringContent(JsonConvert.SerializeObject(item));
                HttpResponseMessage responseMessage = await _httpClient.PostAsync(url, content);
                if (responseMessage != null)
                {
                    responseMessage.EnsureSuccessStatusCode();
                    if (responseMessage.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default;
                    }

                    var responseContent = await responseMessage.Content.ReadAsStringAsync();

                    if (string.IsNullOrWhiteSpace(responseContent))
                    {
                        return default;
                    }

                    var response = JsonConvert.DeserializeObject<T>(responseContent);

                    return response != null ? response : default;
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception.Message, exception);
                return default;
            }

            return default;
        }
    }
}
