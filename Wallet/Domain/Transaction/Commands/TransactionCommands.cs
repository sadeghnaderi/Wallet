using AutoMapper;
using Persistance.Repositories;
using Wallet.Domain.Aggregates;
using Wallet.Domain.Transaction.ValueObjects;
using Wallet.Domain.Entities;
using Wallet.Implementation;

namespace Wallet.Domain.Transaction.Commands
{
    public class TransactionCommands
    {
        public Guid PayToWalletFromBankAccount(BankToWalletTransactionInfo transactionInfo)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            UserRepository userRepository = new UserRepository();

            TransactionAggregate transactionModel = new(Guid.NewGuid(),transactionInfo.Amount, null, transactionInfo.ToWalletId, null, transactionInfo.TransactionType);

            var temp = MapperWrapper.Mapper.Map<Entities.Transaction>(transactionModel);

            UserAggregate userModel = new UserAggregate();
            userModel.SetUserWalletInfo(userRepository.GetWalletById(transactionInfo.ToWalletId));
            userRepository.UpdateWalletAmount(transactionInfo.ToWalletId, userModel.UserWallet.RemainAmount+transactionInfo.Amount);

            return transactionInfo.ToWalletId;
        }
        public Guid PayToBankAccountFromWallet(WalletToBankTransactionInfo transactionInfo)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            UserRepository userRepository = new UserRepository();

            TransactionAggregate model = new(Guid.NewGuid(), transactionInfo.Amount, transactionInfo.FromWalletId, null, transactionInfo.ToBankAccountId, transactionInfo.TransactionType);

            var temp = MapperWrapper.Mapper.Map<Entities.Transaction>(model);

            UserAggregate userModel = new UserAggregate();
            userModel.SetUserWalletInfo(userRepository.GetWalletById(transactionInfo.FromWalletId));
            userRepository.UpdateWalletAmount(transactionInfo.FromWalletId, userModel.UserWallet.RemainAmount - transactionInfo.Amount);

            return transactionRepository.CreateTransaction(temp);
        }
        public Guid TransferBetweenTwoWallet(WalletToWalletTransactionInfo transactionInfo)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            UserRepository userRepository = new UserRepository();

            TransactionAggregate model = new(Guid.NewGuid(), transactionInfo.Amount, transactionInfo.FromWalletId, transactionInfo.ToWalletId, null, transactionInfo.TransactionType);

            var temp = MapperWrapper.Mapper.Map<Entities.Transaction>(model);

            UserAggregate userModel = new UserAggregate();
            userModel.SetUserWalletInfo(userRepository.GetWalletById(transactionInfo.FromWalletId));
            UserAggregate userModel2 = new UserAggregate();
            userModel2.SetUserWalletInfo(userRepository.GetWalletById(transactionInfo.ToWalletId));

            userRepository.UpdateWalletAmount(transactionInfo.FromWalletId, userModel.UserWallet.RemainAmount - transactionInfo.Amount);
            userRepository.UpdateWalletAmount(transactionInfo.ToWalletId, userModel2.UserWallet.RemainAmount + transactionInfo.Amount);

            return transactionRepository.CreateTransaction(temp);
        }
    }
}
