namespace Bitnovo.Banking.Shared.Dto
{
    public class AccountDto
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public string Number { get; set; }

        public decimal Balance { get; set; }
    }
}
