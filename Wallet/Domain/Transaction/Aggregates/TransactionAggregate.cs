using Wallet.Domain.Entities;

namespace Wallet.Domain.Aggregates
{
    public class TransactionAggregate
    {
        public Guid Id { get; private set; }
        public int Amount { get; set; }
        public Guid? FromWalletId { get; set; }
        public Guid? ToWalletId { get; set; }
        public string? ToBankAccountId { get; set; }
        public TransactionType TransactionType { get; private set; }

        public TransactionAggregate(Guid id, int amount, Guid? fromWalletId, Guid? toWalletId,string? toBankAccountId, TransactionType transactionType)
        {
            Id = id;
            Amount = amount;
            FromWalletId = fromWalletId;
            ToWalletId = toWalletId;
            ToBankAccountId = toBankAccountId;
            TransactionType = transactionType;
        }

    }
}
