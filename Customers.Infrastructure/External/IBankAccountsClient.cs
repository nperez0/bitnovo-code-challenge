using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Customers.Infrastructure.External.Queries;
using Bitnovo.Infrastructure.Http;

namespace Bitnovo.Customers.Infrastructure.External
{
    public interface IBankAccountsClient : IHttpClientBase<AccountsQuery, AccountsResponse>
    {
        
    }
}