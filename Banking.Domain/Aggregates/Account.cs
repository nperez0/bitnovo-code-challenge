using Bitnovo.Common;
using System;

namespace Bitnovo.Banking.Domain.Entities
{
    public class Account
    {
        public int Id { get; private set; }

        public StringValue Number { get; private set; }

        public PositiveDecimal Balance { get; private set; }

        public int CustomerId { get; private set; }

        private Account() { }

        private Account(
            int customerId,
            StringValue number,
            PositiveDecimal balance)
        {
            Number = number;
            Balance = balance;
            CustomerId = customerId;
        }

        public static Account Create(int customerId)
            => new Account(
                customerId,
                StringValue.Create(Guid.NewGuid().ToString()).Value,
                PositiveDecimal.Create(0).Value);

        public Result DepositMoney(PositiveDecimal amount)
        {
            var newBalance = Balance.Add(amount);

            return newBalance
                .OnSuccess(UpdateBalance(newBalance.Value));
        }

        public Result WithdrawMoney(PositiveDecimal amount)
        {
            var newBalance = Balance.Subtract(amount);

            return newBalance
                .OnSuccess(UpdateBalance(newBalance.Value))
                .OnFailure(() => Result.Fail("Cannot withdraw in bankaccount, amount is greather than balance."));
        }

        Action UpdateBalance(PositiveDecimal amount)
            => () => Balance = amount;
    }
}
