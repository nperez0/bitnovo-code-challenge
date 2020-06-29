using AutoMapper;
using Bitnovo.Banking.Shared.Dto;
using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Common;
using Bitnovo.Customers.Domain.Aggregates;
using Bitnovo.Customers.Infrastructure.Data;
using Bitnovo.Customers.Infrastructure.External;
using Bitnovo.Customers.Infrastructure.External.Queries;
using Bitnovo.Customers.Shared.Dto;
using Bitnovo.Customers.Shared.Responses;
using Bitnovo.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitnovo.Customers.Application.Services
{
    public class CustomersAppService : ICustomersAppService
    {
        readonly ICustomerRepository _customerRepository;
        readonly IBankAccountsClient _bankAccountsClient;
        readonly IMapper _mapper;

        public CustomersAppService(
            ICustomerRepository customerRepository,
            IBankAccountsClient bankAccountsClient,
            IMapper mapper)
        {
            _customerRepository = customerRepository;
            _bankAccountsClient = bankAccountsClient;
            _mapper = mapper;
        }

        public async Task<Result<CustomersResponse>> GetCustomers()
        {
            var customers = await _customerRepository.GetAll();
            var bankAccounts = await GetBankAccounts(customers);

            return bankAccounts
                .Map(GetResponse(customers));
        }

        Task<Result<AccountsResponse>> GetBankAccounts(IEnumerable<Customer> customers)
            => _bankAccountsClient.ExecuteAsync(BuildBankAccountsQuery(customers));

        AccountsQuery BuildBankAccountsQuery(IEnumerable<Customer> customers)
            => AccountsQuery.Create(customers.Select(c => c.Id));

        Func<AccountsResponse, CustomersResponse> GetResponse(IEnumerable<Customer> customers)
            => response => CustomersResponse.Create(Map(customers, response.Accounts));

        IEnumerable<CustomerDto> Map(IEnumerable<Customer> customers, IEnumerable<AccountDto> bankAccounts)
            => customers.Select(Map(bankAccounts));

        Func<Customer, CustomerDto> Map(IEnumerable<AccountDto> bankAccounts)
            => customer => Map(customer, FindBankAccountOrNothing(customer, bankAccounts));

        Maybe<AccountDto> FindBankAccountOrNothing(Customer customer, IEnumerable<AccountDto> bankAccounts)
            => bankAccounts.SingleOrDefault(b => b.CustomerId == customer.Id);

        CustomerDto Map(Customer customer, Maybe<AccountDto> bankAccountDtoOrNothing)
            => bankAccountDtoOrNothing.HasValue
            ? _mapper.Map<CustomerDto>(customer, bankAccountDtoOrNothing.Value)
            : _mapper.Map<CustomerDto>(customer);
    }
}
