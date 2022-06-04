using Wallet.Domain.Entities;

namespace Wallet.Domain.Transaction.ValueObjects
{
    public class WalletToBankTransactionInfo
    {
        public int Amount { get; set; }
        public string ToBankAccountId { get; set; }
        public Guid FromWalletId { get; set; }
        public TransactionType TransactionType { get; } = TransactionType.FromWalletToBank;
    }
}
