using System.Collections.Generic;
using System.Linq;

namespace Bitnovo.Customers.Infrastructure.External.Queries
{
    public class AccountsQuery
    {
        public IEnumerable<int> CustomerIds { get; }

        private AccountsQuery(IEnumerable<int> customerIds)
        {
            CustomerIds = customerIds.ToList();
        }

        public static AccountsQuery Create(IEnumerable<int> customerIds)
            => new AccountsQuery(customerIds);
    }
}
