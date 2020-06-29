using Bitnovo.Banking.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bitnovo.Banking.Infrastructure.Data
{
    public class ContextSeed
    {
        public void Seed(Context context)
        {
            if (!context.Accounts.Any())
            {
                context.Accounts.AddRange(
                    GetPreconfiguredAccounts());

                context.SaveChanges();
            }
        }

        public List<Account> GetPreconfiguredAccounts()
        {
            var account1 = Account.Create(1);
            var account2 = Account.Create(2);

            account1.DepositMoney(100);
            account2.DepositMoney(500);

            return new List<Account>()
            {
                account1,
                account2
            };
        }
    }
}
