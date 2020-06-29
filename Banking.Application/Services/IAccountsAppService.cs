using System.Threading.Tasks;
using Bitnovo.Banking.Shared.Requests;
using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Common;

namespace Bitnovo.Banking.Application.Services
{
    public interface IAccountsAppService
    {
        Task<Result<AccountsResponse>> GetAccountsByCustomerIds(AccountsRequest request);
    }
}