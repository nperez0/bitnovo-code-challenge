using System.Threading.Tasks;
using Bitnovo.Common;
using Bitnovo.Customers.Shared.Responses;

namespace Bitnovo.Customers.Application.Services
{
    public interface ICustomersAppService
    {
        Task<Result<CustomersResponse>> GetCustomers();
    }
}