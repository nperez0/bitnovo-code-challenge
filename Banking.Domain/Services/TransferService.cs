using Bitnovo.Banking.Domain.Entities;
using Bitnovo.Common;

namespace Bitnovo.Banking.Domain.Services
{
    public class TransferService : ITransferService
    {
        public Result Transfer(
            PositiveDecimal amount,
            Account originAccount,
            Account destinationAccount)
            => originAccount
                .WithdrawMoney(amount)
                .OnSuccess(() => destinationAccount.DepositMoney(amount));
    }
}
