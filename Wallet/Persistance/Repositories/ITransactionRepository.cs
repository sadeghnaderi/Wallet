using Wallet.Domain.Entities;

namespace Persistance.Repositories
{
    public interface ITransactionRepository
    {
        Guid CreateTransaction(Transaction transaction);
        List<Transaction> GetAllTransactions();
        List<Transaction> GetTransactionsByUserId(Guid UserId);
        List<Transaction> GetBankTransactionsByUserId(Guid UserId);
        List<Transaction> GetBetweenTwoWalletTransactionsByUserId(Guid UserId);

    }
}
