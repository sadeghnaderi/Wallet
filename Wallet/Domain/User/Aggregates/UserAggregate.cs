using Wallet.Domain.Entities;

namespace Wallet.Domain.Aggregates
{
    public class UserAggregate
    {
        public Guid Id { get; private set; }
        public string? Name { get; private set; }
        public string? BankAccountId { get; private set; }
        public string? Username { get; private set; }
        public string? Password { get; private set; }

        public UserAggregate()
        {

        }
        public UserAggregate(Guid id, string name, string bankAccountId, string username, string password)
        {
            Id = id;
            Name = name;
            BankAccountId = bankAccountId;
            Username = username;
            Password = password;
        }

        public void SetUserWalletInfo(UserWallet userWallet) => UserWallet = userWallet;


        public void UpdateUserWalletAmount(int remainAmount)
        {
            if (UserWallet != null)
                UserWallet.RemainAmount = remainAmount;
        }
        public UserWallet? UserWallet { get; set; }
    }
}
