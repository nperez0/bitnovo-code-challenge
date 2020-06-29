using System.Collections.Generic;
using System.Threading.Tasks;
using Bitnovo.Banking.Domain.Entities;

namespace Bitnovo.Banking.Infrastructure.Data
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetByCustomerIds(IEnumerable<int> customerIds);
    }
}