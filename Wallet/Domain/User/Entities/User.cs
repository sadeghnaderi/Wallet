namespace Wallet.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? BankAccountId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}
