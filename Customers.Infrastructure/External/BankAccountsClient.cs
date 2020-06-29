using System.Net.Http;
using System.Text;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Customers.Infrastructure.External.Queries;
using Bitnovo.Infrastructure.Http;
using AutoMapper;
using Bitnovo.Banking.Shared.Requests;

namespace Bitnovo.Customers.Infrastructure.External
{
    public class BankAccountsClient : HttpClientBase<AccountsQuery, AccountsResponse>, IBankAccountsClient
    {
        readonly IMapper _mapper;

        public override string ClientName => "Banking";

        public BankAccountsClient(IHttpClientFactory clientFactory, ILogger<BankAccountsClient> logger, IMapper mapper)
            : base(clientFactory, logger)
        {
            _mapper = mapper;
        }

        protected override HttpRequestMessage BuildRequest(AccountsQuery query)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "api/banking/account");
            var payload = _mapper.Map<AccountsRequest>(query);

            request.Content = new StringContent(JsonConvert.SerializeObject(payload), Encoding.UTF8, "application/json");

            return request;
        }
    }
}
