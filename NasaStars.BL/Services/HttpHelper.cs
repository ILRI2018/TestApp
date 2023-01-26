using NasaStars.BL.Interfaces;
using NasaStars.VM.Helpers;
using System.Net;

namespace NasaStars.BL.Services
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public HttpHelper(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<T> GetAsync<T>(string query, string externalAccessToken = null, CancellationToken token = default)
        {
            var handledQuery = HandleAbsoluteUri(query);
            var request = BuildRequest(HttpMethod.Get, handledQuery, externalAccessToken);

            return await ExecuteRequestAsync<T>(request, token: token);
        }

        private string HandleAbsoluteUri(string query)
        {
            if (!Uri.IsWellFormedUriString(query, UriKind.Absolute))
            {
                if (query.StartsWith("/"))
                    query = query.Substring(1);


            }

            return query;
        }

        private HttpRequestMessage BuildRequest(HttpMethod httpMethod, string url, string externalAccessToken = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            return request;
        }

        private async Task<T> ExecuteRequestAsync<T>(HttpRequestMessage request, CancellationToken token = default)
        {
            var client = _httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(60);

            HttpResponseMessage response;

            try
            {
                response = await client.SendAsync(request, token);
            }
            catch (Exception ex)
            {
                throw new Exception("Bad request" + ex.Message);
            }

            if (response.IsSuccessStatusCode)
            {
                return JsonConvertHelper.GetObject<T>(await response.Content.ReadAsStringAsync());
            }
            else if (response.StatusCode == HttpStatusCode.Forbidden)
            {
                throw new Exception("You have no permission to access this resource");
            }
            else if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                throw new Exception("You are not authorized");
            }
            else
            {
                throw new Exception(response.StatusCode.ToString());
            }
        }
    }
}
