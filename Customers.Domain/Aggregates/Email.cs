using Bitnovo.Common;
using System.Text.RegularExpressions;

namespace Bitnovo.Customers.Domain.Aggregates
{
    public class Email : StringValue
    {
        private Email()
            : base(string.Empty)
        {
        }

        private Email(string value)
            : base(value)
        {
            
        }

        public new static Result<Email> Create(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return Result.Fail<Email>("Email should not be empty");

            email = email.Trim();
            if (email.Length > 256)
                return Result.Fail<Email>("Email is too long");

            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                return Result.Fail<Email>("Email is invalid");

            return Result.Ok(new Email(email));
        }
    }
}
