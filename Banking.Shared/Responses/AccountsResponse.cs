using Bitnovo.Banking.Shared.Dto;
using System.Collections.Generic;
using System.Linq;

namespace Bitnovo.Banking.Shared.Responses
{
    public class AccountsResponse
    {
        public IEnumerable<AccountDto> Accounts { get; set; }

        public AccountsResponse() { }

        private AccountsResponse(IEnumerable<AccountDto> accounts)
        {
            Accounts = accounts;
        }

        public static AccountsResponse Create(IEnumerable<AccountDto> accounts)
            => new AccountsResponse(accounts);
    }
}
