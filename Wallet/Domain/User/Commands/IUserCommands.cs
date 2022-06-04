using Wallet.Domain.Transaction.ValueObjects;

namespace Wallet.Domain.User.Commands
{
    public interface IUserCommands
    {
        Guid CreateUser(UserInfo userInfo);
    }
}
