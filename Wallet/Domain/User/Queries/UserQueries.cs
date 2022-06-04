using Persistance.Repositories;

namespace Wallet.Domain.User.Queries
{
    public class UserQueries
    {
        public List<Entities.User> GetAllUsers()
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetAllUsers();
        }
        public Entities.User GetUserById(Guid id)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetUserById(id);
        }
        public Entities.UserWallet GetWalletById(Guid id)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetWalletById(id);
        }
        public Entities.UserWallet GetWalletByUserId(Guid id)
        {
            UserRepository userRepository = new UserRepository();
            return userRepository.GetWalletByUserId(id);
        }
    }
}
