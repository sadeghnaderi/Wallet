using Wallet.Domain.Entities;

namespace Persistance.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private List<Transaction> _transactions = new List<Transaction> { };
        public Guid CreateTransaction(Transaction transaction)
        {
            _transactions.Add(transaction);
            return transaction.Id;
        }

        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        public List<Transaction> GetBankTransactionsByUserId(Guid UserId)
        {
            return (_transactions.Where(m => m.TransactionType == TransactionType.FromWalletToBank
            || m.TransactionType == TransactionType.FromBankToWallet)).ToList();
        }

        public List<Transaction> GetTransactionsByUserId(Guid UserId)
        {
            UserRepository userRepository = new UserRepository();
            Guid WalletId = (userRepository.GetWalletByUserId(UserId)).Id;
            return (_transactions.Where(m => m.FromWalletId == WalletId || m.ToWalletId == WalletId)).ToList();
        }

        public List<Transaction> GetBetweenTwoWalletTransactionsByUserId(Guid UserId)
        {
            return (_transactions.Where(m => m.TransactionType == TransactionType.BetweenTwoWallet)).ToList();
        }
    }
}
