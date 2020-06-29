using Bitnovo.Customers.Shared.Dto;
using System.Collections.Generic;

namespace Bitnovo.Customers.Shared.Responses
{
    public class CustomersResponse
    {
        public IEnumerable<CustomerDto> Customers { get; }

        private CustomersResponse(IEnumerable<CustomerDto> customers)
        {
            Customers = customers;
        }

        public static CustomersResponse Create(IEnumerable<CustomerDto> customers)
            => new CustomersResponse(customers);
    }
}
