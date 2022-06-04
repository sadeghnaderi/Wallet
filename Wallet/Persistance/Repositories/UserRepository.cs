using Wallet.Domain.Entities;

namespace Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private static List<User> _users = new List<User>();
        private static List<UserWallet> _userWallet = new List<UserWallet>();
        public Guid CreateUser(User user)
        {
            _users.Add(user);
            return user.Id;
        }

        public Guid CreateWallet(UserWallet userWallet)
        {
            _userWallet.Add(userWallet);
            return userWallet.Id;
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }

        public User? GetUserById(Guid id)
        {
            return _users.FirstOrDefault(m => m.Id == id);
        }

        public UserWallet? GetWalletById(Guid id)
        {
            return _userWallet.FirstOrDefault(m => m.Id == id);
        }

        public UserWallet? GetWalletByUserId(Guid userId)
        {
            return _userWallet.FirstOrDefault(m => m.UserId == userId);
        }

        public void UpdateWalletAmount(Guid WalletId, int NewAmount)
        {
            GetWalletById(WalletId).RemainAmount = NewAmount;
        }
    }
}
