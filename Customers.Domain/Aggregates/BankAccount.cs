//using System;
//using Bitnovo.Common;

//namespace Bitnovo.Customers.Domain.Entities
//{
//    public class BankAccount
//    {
//        public int Id { get; private set; }

//        public StringValue Number { get; private set; }

//        public PositiveDecimal Balance { get; private set; }

//        public Customer Owner { get; private set; }

//        private BankAccount() { }

//        private BankAccount(
//            Customer owner, 
//            StringValue number,
//            PositiveDecimal balance)
//        {
//            Number = number;
//            Balance = balance;
//            Owner = owner;
//        }

//        public static BankAccount Create(Customer owner)
//            => new BankAccount(
//                owner, 
//                StringValue.Create(Guid.NewGuid().ToString()).Value, 
//                PositiveDecimal.Create(0).Value);

//        public Result DepositMoney(PositiveDecimal amount)
//        {
//            var newBalance = Balance.Add(amount);

//            return newBalance
//                .OnSuccess(UpdateBalance(newBalance.Value));
//        }

//        public Result WithdrawMoney(PositiveDecimal amount)
//        {
//            var newBalance = Balance.Subtract(amount);

//            return newBalance
//                .OnSuccess(UpdateBalance(newBalance.Value))
//                .OnFailure(() => Result.Fail("Cannot withdraw in bankaccount, amount is greather than balance."));
//        }

//        Action UpdateBalance(PositiveDecimal amount)
//            => () => Balance = amount;
//    }
//}
