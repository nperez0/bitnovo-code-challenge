using Bitnovo.Customers.Domain.Aggregates;
using System.Collections.Generic;
using System.Linq;

namespace Bitnovo.Customers.Infrastructure.Data
{
    public class ContextSeed
    {
        public void Seed(Context context)
        {
            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                    GetPreconfiguredCustomers());

                context.SaveChanges();
            }
        }

        public List<Customer> GetPreconfiguredCustomers()
        {
            var user1 = User.Create("ji@test.com", "1234", Roles.Admin);
            var user2 = User.Create("js@test.com", "1234", Roles.User);

            var customer1 = Customer.Create(
                "Julio",
                "Iglesias",
                Email.Create("ji@test.com").Value);

            var customer2 = Customer.Create(
                "Joaquin",
                "Sabina",
                Email.Create("ji@test.com").Value);

            customer1.SetUser(user1);
            customer2.SetUser(user2);

            return new List<Customer>()
            {
                customer1,
                customer2
            };
        }
    }
}
