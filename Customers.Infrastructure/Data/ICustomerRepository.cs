using Bitnovo.Common;
using Bitnovo.Customers.Domain.Aggregates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitnovo.Customers.Infrastructure.Data
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAll();

        Task<Maybe<Customer>> GetById(int id);

        Task Add(Customer customer);

        Task Update(Customer customer);
    }
}
