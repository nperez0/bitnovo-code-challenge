using Bitnovo.Common;

namespace Bitnovo.Customers.Domain.Aggregates
{
    public class User
    {
        public int Id { get; private set;}

        public StringValue Username { get; private set; }

        public StringValue Password { get; private set; }

        public Roles Role { get; private set; }

        public int CustomerId { get; private set; }

        public Customer Customer { get; private set; }

        private User() { }

        private User(StringValue username, StringValue password, Roles role)
        {
            Username = username;
            Password = password;
            Role = role;
        }

        public static User Create(StringValue username, StringValue password, Roles role)
            => new User(
                username,
                password,
                role);
    }
}
