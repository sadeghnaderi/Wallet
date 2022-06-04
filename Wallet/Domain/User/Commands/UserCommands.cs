using AutoMapper;
using Persistance.Repositories;
using Wallet.Domain.Aggregates;
using Wallet.Domain.Transaction.ValueObjects;
using Wallet.Implementation;

namespace Wallet.Domain.User.Commands
{
    public class UserCommands : IUserCommands
    {
        public Guid CreateUser(UserInfo userInfo)
        {
            AutoMapperConfig.Configure();
            UserRepository userRepository = new UserRepository();
            Guid UserId = Guid.NewGuid();
            UserAggregate userModel = new(UserId,userInfo.Name,userInfo.BankAccountId,userInfo.Username,userInfo.Password);
            
            var temp = MapperWrapper.Mapper.Map<Entities.User>(userModel);

            userModel.SetUserWalletInfo(new Entities.UserWallet { Id = Guid.NewGuid(),RemainAmount = 0,UserId = UserId});

            userRepository.CreateWallet(userModel.UserWallet);

            return userRepository.CreateUser(temp);

        }
    }
}
