//using Balance.Common;
//using Balance.Domain.Entities;

//namespace Balance.Domain.Services
//{
//    public class BankTransferService : IBankTransferService
//    {
//        public Result Transfer(
//            PositiveDecimal amount,
//            BankAccount originAccount,
//            BankAccount destinationAccount)
//            => originAccount
//                .WithdrawMoney(amount)
//                .OnSuccess(() => destinationAccount.DepositMoney(amount));
//    }
//}
