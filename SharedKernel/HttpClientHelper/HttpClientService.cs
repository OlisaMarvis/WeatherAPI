using Newtonsoft.Json;
using System.Text;

namespace WeatherApp.SharedKernel.HttpClientHelper
{
    public class HttpClientService : IHttpClientService
    {
        private readonly HttpClient _httpClient;

        public HttpClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Tout> GetAsync<Tout>(string requestUrl, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, requestUrl);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<Tout>(responseContent);
                    return result!;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error while deserializing response content: {responseContent}", ex);
                }

            }
            throw new Exception($"Error while calling {requestUrl} with status code: {response.StatusCode} and content: {responseContent}");
        }


        public async Task<Tout> PostAsync<Tin, Tout>(string requestUrl, Tin data, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, requestUrl);
            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var dataAsString = JsonConvert.SerializeObject(data);
            request.Content = new StringContent(dataAsString, Encoding.UTF8, "application/json");

            var response = await _httpClient.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                responseContent = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<Tout>(responseContent);
                    return result!;
                }
                catch (Exception ex)
                {
                    throw new Exception($"Error while deserializing response content: {responseContent}", ex);
                }

            }
            throw new Exception($"Error while calling {requestUrl} with status code: {response.StatusCode} and content: {responseContent}");
        }

    }
}
