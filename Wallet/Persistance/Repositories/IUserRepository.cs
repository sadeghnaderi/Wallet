using Wallet.Domain.Entities;

namespace Persistance.Repositories
{
    public interface IUserRepository
    {
        Guid CreateUser(User user);
        User? GetUserById(Guid id);
        List<User> GetAllUsers();
        Guid CreateWallet(UserWallet userWallet);
        UserWallet? GetWalletById(Guid id);
        UserWallet? GetWalletByUserId(Guid userId);
        void UpdateWalletAmount(Guid WalletId, int NewAmount);

    }
}
