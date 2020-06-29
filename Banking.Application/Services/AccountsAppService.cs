using AutoMapper;
using Bitnovo.Banking.Domain.Entities;
using Bitnovo.Banking.Infrastructure.Data;
using Bitnovo.Banking.Shared.Dto;
using Bitnovo.Banking.Shared.Requests;
using Bitnovo.Banking.Shared.Responses;
using Bitnovo.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Bitnovo.Banking.Application.Services
{
    public class AccountsAppService : IAccountsAppService
    {
        readonly IAccountRepository _accountRepository;
        IMapper _mapper;

        public AccountsAppService(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<Result<AccountsResponse>> GetAccountsByCustomerIds(AccountsRequest request)
        {
            var accounts = await _accountRepository.GetByCustomerIds(request.CustomerIds);

            return Result.Ok(Map(accounts));
        }

        AccountsResponse Map(IEnumerable<Account> accounts)
            => AccountsResponse.Create(_mapper.Map<IEnumerable<AccountDto>>(accounts));
    }
}
