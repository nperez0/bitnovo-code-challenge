using Bitnovo.Common;

namespace Bitnovo.Customers.Domain.Aggregates
{
    public class Customer
    {
        public int Id { get; private set; }

        public StringValue FirstName { get; private set; }

        public StringValue Surname { get; private set; }

        public Email Email { get; private set; }

        public int UserId { get; private set; }

        public User User { get; private set; }

        private Customer() { }

        private Customer(
            StringValue firstName, 
            StringValue surname, 
            Email email)
        {
            FirstName = firstName;
            Surname = surname;
            Email = email;
        }

        public Result UpdateEmail(Email newEmail)
        {
            Email = newEmail;

            return Result.Ok();
        }

        public Result SetUser(User user)
        {
            User = user;

            return Result.Ok();
        }

        public static Customer Create(
            StringValue firstName,
            StringValue surname,
            Email email)
            => new Customer(firstName,
                surname,
                email);
    }
}
