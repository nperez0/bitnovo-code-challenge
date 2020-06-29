using Bitnovo.Common;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bitnovo.Infrastructure.Http
{
    public abstract class HttpClientBase<TQuery, TModel> : IHttpClientBase<TQuery, TModel>
    {
        readonly IHttpClientFactory _clientFactory;
        readonly ILogger _logger;

        public abstract string ClientName { get; }

        public HttpClientBase(IHttpClientFactory clientFactory, ILogger logger)
        {
            _clientFactory = clientFactory;

            _logger = logger;
        }

        public virtual async Task<Result<TModel>> ExecuteAsync(TQuery query)
        {
            try
            {
                using (var client = _clientFactory.CreateClient(ClientName))
                {
                    var request = BuildRequest(query);

                    using (var response = await client.SendAsync(request))
                    {
                        return await GetResult(response);
                    }
                }

            }
            catch (WebException ex)
            {
                _logger.LogError(ex, $"Error when calling: {ClientName}");

                return Result.Fail<TModel>($"Error calling the api!");
            }
        }

        protected abstract HttpRequestMessage BuildRequest(TQuery query);

        async Task<Result<TModel>> GetResult(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                _logger.LogError($"Error when calling: {ClientName}, reason: {response.ReasonPhrase}");

                return Result.Fail<TModel>($"Could not possible get info from {ClientName}!");
            }

            var result = await response.Content
                .ReadAsAsync<TModel>();

            return result == null
                ? Result.Fail<TModel>($"Could not parse Api response {ClientName}!")
                : Result.Ok(result);
        }
    }
}
