using Persistance.Repositories;

namespace Wallet.Domain.Transaction.Queries
{
    public class TransactionQueries
    {
        public List<Entities.Transaction> GetAllTransactions()
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            return transactionRepository.GetAllTransactions();
        }

        public List<Entities.Transaction> GetTransactionsByUserId(Guid UserId)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            return transactionRepository.GetTransactionsByUserId(UserId);
        }

        public List<Entities.Transaction> GetBankTransactionsByUserId(Guid UserId)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            return transactionRepository.GetBankTransactionsByUserId(UserId);
        }

        public List<Entities.Transaction> GetBetweenTwoWalletTransactionsByUserId(Guid UserId)
        {
            TransactionRepository transactionRepository = new TransactionRepository();
            return transactionRepository.GetBetweenTwoWalletTransactionsByUserId(UserId);
        }
    }
}
