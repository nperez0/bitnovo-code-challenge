using Bitnovo.Banking.Domain.Entities;
using Bitnovo.Common;

namespace Bitnovo.Banking.Domain.Services
{
    public interface ITransferService
    {
        Result Transfer(PositiveDecimal amount, Account originAccount, Account destinationAccount);
    }
}