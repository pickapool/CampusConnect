using Domain;
using Presentation.Interfaces;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Presentation.Services.BaseService
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        private readonly ITokenProvider _tokenProvider;

        public BaseService(IHttpClientFactory httpClientFactory, ITokenProvider tokenProvider)
        {
            _httpClientFactory = httpClientFactory;
            _tokenProvider = tokenProvider;
        }
        public async Task<T> SendAsync<T>(RequestModel request)
        {
            HttpClient httpClient = _httpClientFactory.CreateClient("WebAPI");

            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");

            var token = await _tokenProvider.GetToken();

            if(token is not null)
                if (!string.IsNullOrEmpty(token.AccessToken))
                    message.Headers.Add("Authorization", $"Bearer {token.AccessToken}");

            message.RequestUri = new Uri(request.RequestUrl);

            if (request.Data != null)
                message.Content = new StringContent(JsonSerializer.Serialize(request.Data), Encoding.UTF8, "application/json");
            else
                message.Content = new StringContent("{}", Encoding.UTF8, "application/json");

            HttpResponseMessage response = null;

            switch (request.RequestType)
            {
                case Enums.RequestType.GET:
                    message.Method = HttpMethod.Get;
                    break;
                case Enums.RequestType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Enums.RequestType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Enums.RequestType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    throw new InvalidOperationException("Unsupported request type.");
            }
            response = await httpClient.SendAsync(message);

            if (!response.IsSuccessStatusCode)
                throw new Exception(await response.Content.ReadAsStringAsync());

            return await response.Content.ReadFromJsonAsync<T>();
        }
    }
}
